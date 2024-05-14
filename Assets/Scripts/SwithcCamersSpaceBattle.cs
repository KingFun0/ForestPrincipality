using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwithcCamersSpaceBattle : MonoBehaviour
{
    public Camera mainCamera;
    public Camera otherCamera;



    private void Start()
    {
        mainCamera.gameObject.SetActive(true);
        otherCamera.gameObject.SetActive(false);
    }
    public void SwitchCameras()
    {
            mainCamera.gameObject.SetActive(false);
            otherCamera.gameObject.SetActive(true);
    }
}
