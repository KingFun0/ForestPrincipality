using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl1 : MonoBehaviour
{
    public int scoreValueNormal = 1; // Очки за уничтожение врага
    private ScoreManagerNormal scoreManagerNormal;
    float speed;

    public int health = 20; // Здоровье врага

    // Вызывается при попадании снаряда
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    // Функция вызывается, когда здоровье врага меньше или равно нулю
    void Die()
    {
        // Дополнительные действия при смерти врага
        Destroy(gameObject); // Уничтожаем объект врага
    }

    void Start()
    {
        speed = 2.5f;
        scoreManagerNormal = FindObjectOfType<ScoreManagerNormal>();
    }

    void Update()
    {
        MoveEnemy();

        CheckIfBelowScreen();
    }

    void MoveEnemy()
    {
        Vector2 position = transform.position;
        position = new Vector2(position.x, position.y - speed * Time.deltaTime);
        transform.position = position;
    }

    void CheckIfBelowScreen()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        if (transform.position.y < min.y)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            Destroy(other.gameObject); // Уничтожаем снаряд
            Destroy(gameObject); // Уничтожаем врага
            HandleScoreNormal();
           

        }
    }

    void OnDestroy()
    {
        HandleScoreNormal();
    }

    void HandleScoreNormal()
    {
        if (scoreManagerNormal != null)
        {
            scoreManagerNormal.AddScoreNormal(scoreValueNormal);
        }
        
    }
}
