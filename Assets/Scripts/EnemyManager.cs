using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<GameObject> inamici; 
    public Transform jucator; 
    private int indexInamicCurent = 0;
    private int inamiciEliminati = 0; 
    private GameUIController uiController;
    void Start()
    {
        uiController = FindObjectOfType<GameUIController>();
        DezactiveazaTotiInamicii();
       // ActiveazaUrmatorulInamic();
        ActualizeazaUI();
    }

    void DezactiveazaTotiInamicii()
    {
        foreach (GameObject inamic in inamici)
            inamic.SetActive(false);
    }

    public void ActiveazaUrmatorulInamic()
    {
        if (indexInamicCurent >= inamici.Count)
            return;
        GameObject inamic = inamici[indexInamicCurent];
        inamic.SetActive(true);
        ControlInamic controlInamic = inamic.GetComponent<ControlInamic>();
        if (controlInamic != null)
            controlInamic.SeteazaJucator(jucator);
        indexInamicCurent++;
    }
    public void InamicEliminat()
    {
        inamiciEliminati++;
        ActualizeazaUI();
        if (inamiciEliminati < inamici.Count)
            ActiveazaUrmatorulInamic();
    }

    private void ActualizeazaUI()
    {
        if (uiController != null)
            uiController.UpdateEnemies(inamiciEliminati, inamici.Count);
    }

    public void ResetEnemies()
    {
        indexInamicCurent = 0;
        inamiciEliminati = 0;

        DezactiveazaTotiInamicii();
        ActualizeazaUI();
    }
}
