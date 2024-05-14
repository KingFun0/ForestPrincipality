using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public Transform firePoint; // Место, откуда происходит выстрел
    public GameObject bulletPrefab; // Префаб снаряда
    public float bulletForce = 10f; // Сила выстрела

    public float fireRate = 2f; // Частота выстрелов
    private float nextFireTime = 0;

    private void Update()
    {
        if (Time.time > nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
