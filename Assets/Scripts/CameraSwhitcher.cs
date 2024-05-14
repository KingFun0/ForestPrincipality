using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwhitcher : MonoBehaviour
{
    public Camera mainCamera;
    public Camera otherCamera;

    private Camera currentActiveCamera;


        private void Start()
        {
            mainCamera.gameObject.SetActive(true);
            otherCamera.gameObject.SetActive(false);
        }
 

    private void Update()
    {
        // Переключаем камеры по нажатию клавиши Q
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SwitchCameras();
        }
    }
    public void SwitchCameras()
    {
        // Переключаем камеры
        if (currentActiveCamera == mainCamera)
        {
            mainCamera.gameObject.SetActive(false);
            otherCamera.gameObject.SetActive(true);
            currentActiveCamera = otherCamera;
        }
        else
        {
            mainCamera.gameObject.SetActive(true);
            otherCamera.gameObject.SetActive(false);
            currentActiveCamera = mainCamera;
        }
    }
}
