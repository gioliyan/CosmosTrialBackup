using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ship_Stats
{
    public float maxHealth;
    public float currentHealth;
}

public class Ship_Controller : MonoBehaviour
{
    Rigidbody rb;
    public Ship_Stats stats;

    public GameObject bullet;
    public Transform[] firePoints = new Transform[2];
    public float fireRate;
    private float nextFire;

    public GameObject explosionPrefab;

    public float moveSpeed;
    public float tiltAngle;
    public GameObject alert;
    public GameObject victory;

    private void Start()
    {
        rb = transform.GetComponent<Rigidbody>();

        stats.currentHealth = stats.maxHealth;

        nextFire = 1 / fireRate;
    }

    private void Update()
    {
        if (stats.currentHealth <= 0)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            alert.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        float moveLR = Input.GetAxis("Horizontal");
        float moveFB = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveLR, 0, moveFB);
        rb.velocity = movement * moveSpeed;

        rb.rotation = Quaternion.Euler(Vector3.forward * moveLR * -tiltAngle);

        bool fireButton = Input.GetButton("Fire1");

        Collider[] shipColliders = transform.GetComponentsInChildren<Collider>();

        if (fireButton)
        {
            nextFire -= Time.fixedDeltaTime;
            if (nextFire <= 0)
            {
                for(int i = 0; i < 2; i++)
                {
                    GameObject bulletClone = Instantiate(bullet, firePoints[i].position, Quaternion.identity);

                    for(int x = 0; x < shipColliders.Length; x++)
                    {
                        Physics.IgnoreCollision(bulletClone.transform.GetComponent<Collider>(), shipColliders[x]);
                    }
                }
                nextFire += 1 / fireRate;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            stats.currentHealth -= collision.transform.GetComponent<Asteroid_Controller>().stats.damage;

        }

        if (collision.gameObject.tag == "Enemy")
        {
            stats.currentHealth -= collision.transform.GetComponent<Enemy_Ship>().stats.damage;

        }

        if (collision.gameObject.tag == "EnergyCargo")
        {
            stats.currentHealth += 30;
            if (stats.currentHealth > 100)
            {
                stats.currentHealth = 100;
            }

        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Gate")
        {   
            victory.SetActive(true);
        }
    }
}