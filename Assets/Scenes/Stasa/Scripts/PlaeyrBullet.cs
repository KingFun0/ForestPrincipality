using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    float speed;
    public int damage = 20; // Урон снаряда

    void OnTriggerEnter(Collider other)
    {
        // Проверяем, столкнулись ли снаряд и враг
        if (other.CompareTag("Enemy"))
        {
            // Получаем компонент врага и наносим урон
            EnemyControl enemy = other.GetComponent<EnemyControl>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            // Увеличиваем количество выстрелов в скрипте PlayerControl
            PlayerControl playerControl = FindObjectOfType<PlayerControl>();
            if (playerControl != null)
            {
                playerControl.IncreaseBullets();
            }

            // Уничтожаем снаряд после столкновения
            Destroy(gameObject);
        }
    }

    void Start()
    {
        speed = 8f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;
        position = new Vector2(position.x, position.y + speed * Time.deltaTime);
        transform.position = position;

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        if (transform.position.y > max.y)
        {
            Destroy(gameObject);
        }
    }
}
