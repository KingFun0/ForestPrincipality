using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitPlayerToCamera : MonoBehaviour
{
    private Camera mainCamera;
    private float minX, maxX, minY, maxY;
    private float num = 0.3f; // более точные рамки


    void Start()
    {
        mainCamera = Camera.main;

        if (mainCamera == null)
        {
            Debug.LogError("No main camera found!");
            return;
        }
        
        // Вычислите граничные координаты для камеры
        float camHeight = mainCamera.orthographicSize;
        float camWidth = camHeight * mainCamera.aspect;

        minX = mainCamera.transform.position.x - camWidth + num;
        maxX = mainCamera.transform.position.x + camWidth - num;
        minY = mainCamera.transform.position.y - camHeight + num;
        maxY = mainCamera.transform.position.y + camHeight - num;
    }

    void Update()
    {
        // Получите текущую позицию персонажа
        Vector3 clampedPosition = transform.position;

        // Ограничьте его в пределах камеры
        clampedPosition.x = Mathf.Clamp(transform.position.x, minX, maxX);
        clampedPosition.y = Mathf.Clamp(transform.position.y, minY, maxY);

        // Установите ограниченную позицию
        transform.position = clampedPosition;
    }
}
