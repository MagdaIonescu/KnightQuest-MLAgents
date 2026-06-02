using UnityEngine;

public class DynamicLoading : MonoBehaviour
{
    public GameObject obiect;
    public Vector3 pozitie;
    public Vector3 zonaIncarcare;

    public GameObject cheiaCurenta;

    void Start()
    {
        InstantiereObiect();
    }

    public void InstantiereObiect()
    {
        Vector3 pozitieAleatorie = new Vector3(
            Random.Range(pozitie.x - zonaIncarcare.x, pozitie.x + zonaIncarcare.x),
            pozitie.y,
            Random.Range(pozitie.z - zonaIncarcare.z, pozitie.z + zonaIncarcare.z)
        );

        Quaternion rotatie = Quaternion.Euler(100, 0, 0);

        cheiaCurenta = Instantiate(obiect, pozitieAleatorie, rotatie);
    }
}