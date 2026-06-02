using UnityEngine;

public class CameraTPSFollow : MonoBehaviour
{
    public Transform player; 
    public Vector3 offset = new Vector3(0, 1.8f, -10);

    void LateUpdate()
    {
        if (player != null)
        {
            transform.position = player.position + player.TransformDirection(offset);
            transform.LookAt(player.position + Vector3.up * 1.5f);
        }
    }
}