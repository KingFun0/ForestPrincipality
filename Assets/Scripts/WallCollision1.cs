using UnityEngine;

public class WallCollision1 : MonoBehaviour
{
    // Ссылка на компонент Rigidbody игрока
    private Rigidbody rb;

    // Инициализация
    private void Start()
    {
        // Получаем компонент Rigidbody игрока
        rb = GetComponent<Rigidbody>();
    }

    // Функция вызывается, когда происходит коллизия с другим объектом
    private void OnCollisionEnter(Collision collision)
    {
        // Проверяем, есть ли у объекта тэг "Wall"
        if (collision.gameObject.CompareTag("Wall"))
        {
            // Если есть, то блокируем движение персонажа
            Debug.Log("Столкновение с объектом Wall!");

            // Останавливаем движение игрока
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            // Дополнительные действия, если необходимо
        }
    }
}
