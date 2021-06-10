using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Enemy_stat
{
    public float maxHealth;
    public float currentHealth;
    public float damage;
}

public class Enemy_Ship : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject bulletPrefab;
    public Transform firePoint;

    public float moveSpeed;
    public float shootSpeed;
    public float shootSpeedTime;

    public Enemy_stat stats;

    public GameObject explosionPrefab;


    void Start()
    {
        shootSpeedTime = shootSpeed;

        stats.currentHealth = stats.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0f, 0f, moveSpeed * Time.deltaTime);

        //shooting
        if (shootSpeedTime <= 0f)
        {
            shoot();
            shootSpeedTime = shootSpeed;
        }
        else
        {
            shootSpeedTime -= Time.deltaTime;
        }

        if (stats.currentHealth <= 0)
        {
            explode();
            Destroy(gameObject);
        }
    }

    public void explode(){
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
    } 

    void shoot()
    {
        GameObject bulletGO = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation) as GameObject;
        Destroy(bulletGO, 10f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {            
            explode();
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Tembok")
        {
            Destroy(gameObject);
        }
    }
}
