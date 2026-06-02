using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;
using UnityEngine.SceneManagement;

public class KnightAgent : Agent
{
    public float speed = 20f;
    public bool trainingMode = true;

    public GameObject enemy;

    private Transform key;
    private Transform currentEnemy;

    private CharacterController controller;
    private DynamicLoading loader;
    private MaleCharacter attackScript;

    private Vector3 startPos = new Vector3(20f, 1f, 7f);

    private float previousDistance;

    private bool combatMode = false;
    private bool gameCompleted = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        loader = FindObjectOfType<DynamicLoading>();
        attackScript = GetComponent<MaleCharacter>();

        Debug.Log("KnightAgent started");
    }

    public override void OnEpisodeBegin()
    {
        combatMode = false;
        gameCompleted = false;
        currentEnemy = null;

        EnemyManager manager = FindObjectOfType<EnemyManager>();

        if (manager != null)
            manager.ResetEnemies();

        controller.enabled = false;
        transform.position = startPos;
        controller.enabled = true;

        CollectKeys collectScript = GetComponent<CollectKeys>();

        if (collectScript != null)
        {
            collectScript.keysCollected = 0;

            GameUIController ui = FindObjectOfType<GameUIController>();
            if (ui != null)
                ui.UpdateKeys(0);
        }

        if (loader.cheiaCurenta != null)
            Destroy(loader.cheiaCurenta);

        loader.InstantiereObiect();
        key = loader.cheiaCurenta.transform;

        previousDistance =
            Vector3.Distance(transform.position, key.position);
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        Transform target = null;

        if (!combatMode)
            target = key;
        else
            target = currentEnemy;

        if (target == null)
        {
            sensor.AddObservation(Vector3.zero);
            sensor.AddObservation(Vector3.zero);
            return;
        }

        Vector3 direction = target.position - transform.position;

        sensor.AddObservation(direction.normalized);
        sensor.AddObservation(transform.forward);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        if (gameCompleted)
            return;

        float moveX = actions.ContinuousActions[0];
        float moveZ = actions.ContinuousActions[1];

        Vector3 movement = new Vector3(moveX, 0, moveZ);

        controller.Move(movement * speed * Time.deltaTime);

        Transform target = !combatMode ? key : currentEnemy;

        if (target == null)
            return;

        float currentDistance = Vector3.Distance(transform.position, target.position);

        if (currentDistance < previousDistance)
            AddReward(0.5f);
        else
            AddReward(-0.5f);

        if (movement.magnitude < 0.1f)
            AddReward(-1f);

        previousDistance = currentDistance;

        //-----------------------------------
        // STAGE 1 - KEYS
        //-----------------------------------
        if (!combatMode && currentDistance < 1.5f)
        {
            CollectKeys collectScript = GetComponent<CollectKeys>();

            if (collectScript != null)
            {
                collectScript.keysCollected++;

                GameUIController ui =
                    FindObjectOfType<GameUIController>();

                if (ui != null)
                    ui.UpdateKeys(collectScript.keysCollected);

                Destroy(key.gameObject);

                if (collectScript.keysCollected >= 3)
                {
                    if (ui != null)
                        ui.ShowMessage("Enemy!");

                    combatMode = true;
                    key = null;

                    EnemyManager manager =
                        FindObjectOfType<EnemyManager>();

                    if (manager != null)
                    {
                        manager.ActiveazaUrmatorulInamic();

                        if (manager.inamici.Count > 0)
                            currentEnemy = manager.inamici[0].transform;
                    }

                    AddReward(150f);
                    return;
                }

                loader.InstantiereObiect();
                key = loader.cheiaCurenta.transform;

                previousDistance =
                    Vector3.Distance(
                        transform.position,
                        key.position
                    );
            }

            AddReward(30f);
        }

        //-----------------------------------
        // STAGE 2 - ENEMIES
        //-----------------------------------
        if (combatMode && currentEnemy != null)
        {
            if (currentDistance < 2f)
            {
                Vector3 lookPos = currentEnemy.position;
                lookPos.y = transform.position.y;

                transform.LookAt(lookPos);

                Vector3 attackMove =
                    transform.right *
                    Mathf.Sin(Time.time * 18f) * 7f;

                controller.Move(attackMove * Time.deltaTime);

                attackScript.Attack();
            }

            if (!currentEnemy.gameObject.activeSelf)
            {
                GameUIController ui =
                    FindObjectOfType<GameUIController>();

                EnemyManager manager =
                    FindObjectOfType<EnemyManager>();

                if (ui != null && manager != null)
                {
                    if (ui.GetEnemiesLeft() >= 3)
                    {
                        gameCompleted = true;
                        if (trainingMode)
                            EndEpisode();
                        else
                            SceneManager.LoadScene("LastScene");

                        return;
                    }
                    else
                    {
                        ui.ShowMessage("Next Enemy");

                        manager.ActiveazaUrmatorulInamic();

                        currentEnemy =
                            manager.inamici[
                                ui.GetEnemiesLeft()
                            ].transform;

                        previousDistance =
                            Vector3.Distance(
                                transform.position,
                                currentEnemy.position
                            );
                    }
                }
            }
        }

        //-----------------------------------
        // MAP LIMIT
        //-----------------------------------
        if (transform.position.x < -20 || transform.position.x > 40 ||
            transform.position.z < -10 || transform.position.z > 30)
        {
            SetReward(-20f);
            EndEpisode();
        }
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var actions = actionsOut.ContinuousActions;

        actions[0] = Input.GetAxis("Horizontal");
        actions[1] = Input.GetAxis("Vertical");
    }
}