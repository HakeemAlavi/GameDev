using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleCamera : MonoBehaviour
{
    public GameObject mainCam;
    public GameObject faceCam;

    void Update()
    {
        if (Input.GetButtonDown("1Key"))
        {
            faceCam.SetActive(false);
            mainCam.SetActive(true);
        }

        if (Input.GetButtonDown("2Key"))
        {
            faceCam.SetActive(true);
            mainCam.SetActive(false);
        }
    }
}
