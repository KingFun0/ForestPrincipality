using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public GameObject PlayerBulletGO;
    public GameObject BulletPosition01;
    public GameObject BulletPosition02;

    public float speed = 1f;
    public int maxBullets = 3;
    public int currentBullets;
    public Text bulletsText;

    // Start is called before the first frame update
    void Start()
    {
        currentBullets = maxBullets;
        //bulletsText = GameObject.Find("BulletsText").GetComponent<Text>();
        UpdateBulletsText();
    }
    public void IncreaseBullets()
    {
        currentBullets++;
        UpdateBulletsText();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && currentBullets > 0)
        {
            FireBullet();
            currentBullets--;
            UpdateBulletsText();
        }

        float movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * speed * Time.deltaTime;
        float movement1 = Input.GetAxis("Vertical");
        transform.position += new Vector3(0, movement1, 0) * speed * Time.deltaTime;
    }

    void FireBullet()
    {
        GameObject bullet01 = Instantiate(PlayerBulletGO);
        bullet01.transform.position = BulletPosition01.transform.position;

        GameObject bullet02 = Instantiate(PlayerBulletGO);
        bullet02.transform.position = BulletPosition02.transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            
        }
    }

    void UpdateBulletsText()
    {
        bulletsText.text = "Bullets: " + currentBullets.ToString();
    }
}
