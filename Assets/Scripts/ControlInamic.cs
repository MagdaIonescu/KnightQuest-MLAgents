using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ControlInamic : MonoBehaviour
{
    private NavMeshAgent agent; 
    private Transform jucator;
    public float distantaAtac = 2f; 
    public float dauneAtac = 10f; 
    public float timpIntreAtacuri = 1f; 
    private float ultimulTimpAtac = 0f; 

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (jucator != null && agent.isOnNavMesh)
        {
            agent.SetDestination(jucator.position); 
            float distanta = Vector3.Distance(transform.position, jucator.position);
            if (distanta <= distantaAtac)
                AtacaJucator();
        }
    }
    public void SeteazaJucator(Transform jucatorTransform)
    {
        jucator = jucatorTransform; 
    }
    void AtacaJucator()
    {
        if (Time.time - ultimulTimpAtac >= timpIntreAtacuri)
        {
            PlayerHealth viataJucator = jucator.GetComponent<PlayerHealth>();
            if (viataJucator != null)
                viataJucator.TakeDamage(dauneAtac); 
            ultimulTimpAtac = Time.time; 
        }
    }
}
