using UnityEngine;

public class CameraTopFollow : MonoBehaviour
{
    public Transform player; 
    public Vector3 offset = new Vector3(0, 15, 0); 

    void LateUpdate()
    {
        if (player != null)
        {
            transform.position = player.position + offset;
        }
    }
}
