using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Controller : MonoBehaviour
{
    public float BulletSpeed;

    private GameController gameController;

    public float damage;

    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent <GameController>();
        }
        if (gameController == null)
        {
            Debug.Log ("Cannot find 'GameController' script");
        }
        transform.GetComponent<Rigidbody>().velocity = transform.forward * BulletSpeed;
    }

    private void Update()
    {
        Destroy(gameObject, 2);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            collision.transform.GetComponent<Asteroid_Controller>().stats.currentHealth -= damage;
            Destroy(gameObject);
            gameController.AddScore();
        }

        if (collision.gameObject.tag == "Enemy")
        {
            collision.transform.GetComponent<Enemy_Ship>().stats.currentHealth -= damage;
            gameController.AddScore();
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "EnemyBullet")
        {
            Destroy(gameObject);
        }
    }
}