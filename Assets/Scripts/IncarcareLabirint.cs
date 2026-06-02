using UnityEngine;
using System.IO; 

public class IncarcareObiect : MonoBehaviour
{
    public GameObject perete;
    public Vector3 pozitie;
    public Vector3 zonaIncarcare;
    public float scale = 1.0f;

    void Start()
    {
        int[,] labirint = CitesteLabirintDinFisier("C:\\Users\\Magda\\Desktop\\AN IV\\Programarea jocurilor\\Proiect\\Assets\\Labirint.txt"); 
        GenerareLabirint(labirint);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(pozitie, zonaIncarcare);
    }

    void GenerareLabirint(int[,] labirint)
    {
        for (int i = 0; i < labirint.GetLength(0); i++)
        {
            for (int j = 0; j < labirint.GetLength(1); j++)
            {
                if (labirint[i, j] == 1)
                {
                    Vector3 offset = new Vector3(i * scale + pozitie.x, 0, j * scale + pozitie.z);
                    Instantiate(perete, offset, Quaternion.identity);
                }
            }
        }
    }

    int[,] CitesteLabirintDinFisier(string caleFisier)
    {
            string[] linii = File.ReadAllLines(caleFisier); 
            int rows = linii.Length;
            int cols = linii[0].Split(' ').Length; 
            int[,] matrice = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                string[] valori = linii[i].Split(' '); 
                for (int j = 0; j < cols; j++)
                {
                    matrice[i, j] = int.Parse(valori[j]); 
                }
            }

            return matrice;
    }
}
