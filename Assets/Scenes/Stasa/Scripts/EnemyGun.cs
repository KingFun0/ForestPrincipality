using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    public GameObject EnemyBelletGO;

    void Start()
    {
        Invoke("FireEnemyBullet", 1f);
    }

    
    void Update()
    {
        
    }

    void FireEnemyBullet()
    {
        GameObject playerShip = GameObject.Find ("PlayerGO");

        if(playerShip != null)
        {
            GameObject bullet = (GameObject)Instantiate(EnemyBelletGO);

            bullet.transform.position = transform.position;

            Vector2 directoin = playerShip.transform.position - bullet.transform.position;

            bullet.GetComponent<EnemyBullet>().SetDirection(directoin);
        }
    }
}
