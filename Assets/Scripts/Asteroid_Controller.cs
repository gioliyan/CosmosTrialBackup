using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Asteroid_Stats
{
    public float maxHealth;
    public float currentHealth;
    
    public float damage;
}

public class Asteroid_Controller : MonoBehaviour
{
    public Asteroid_Stats stats;

    private Quaternion randomRotation;

    public GameObject explosionPrefab;
    private AudioSource source;

    private void Start()
    {
        stats.currentHealth = stats.maxHealth;
        source = GetComponent<AudioSource>();
        randomRotation = Random.rotation;
    }
    public void explode(){
        source.Play();
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
    }   
    private void Update()
    {
        transform.Rotate(randomRotation.eulerAngles * 0.1f * Time.deltaTime);

        if (stats.currentHealth <= 0)
        {
            explode();
            Destroy(gameObject);
        }
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