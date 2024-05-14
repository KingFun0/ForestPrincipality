using UnityEngine;

public class RandomPrefabSpawner : MonoBehaviour
{
    public GameObject prefabToSpawn; // Префаб для спавна
    public float spawnRate = 2f; // Частота спавна
    private float nextSpawnTime = 0f;

    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            SpawnPrefab();
            nextSpawnTime = Time.time + spawnRate;
        }
    }

    void SpawnPrefab()
    {
        // Определяем границы камеры
        float camHeight = 2f * Camera.main.orthographicSize;
        float camWidth = camHeight * Camera.main.aspect;

        // Генерируем случайные координаты только по горизонтали в пределах границ экрана
        float randomX = Random.Range(-camWidth / 2f, camWidth / 2f);
        float randomY = camHeight / 2f; // Спавн только сверху

        // Создаем объект в рассчитанной позиции в верхней части камеры
        Vector3 spawnPosition = new Vector3(randomX, randomY, 0);
        Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
    }
}
