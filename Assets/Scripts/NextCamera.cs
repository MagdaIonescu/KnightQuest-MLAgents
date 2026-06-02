using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextCamera : MonoBehaviour
{
    public GameObject cameraFPS;
    public GameObject cameraTop;
    public GameObject cameraTPS;
    private int number = 1;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            switch (number)
            {
                case 1:
                    cameraFPS.SetActive(true);
                    cameraTop.SetActive(false);
                    cameraTPS.SetActive(false);
                    number++;
                    break;
                case 2:
                    cameraFPS.SetActive(false);
                    cameraTop.SetActive(true);
                    cameraTPS.SetActive(false);
                    number++;
                    break;
                case 3:
                    cameraFPS.SetActive(false);
                    cameraTop.SetActive(false);
                    cameraTPS.SetActive(true);
                    number = 1;
                    break;
            }
        }

    }
}