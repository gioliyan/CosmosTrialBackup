using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn_Script : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemyPrefab;

    public float minX;
    public float maxX;

    public float enemySpawnRate;
    // private float curEnemySpawnRate;

    public float spawnTime; 


    void Start()
    {
        //curEnemySpawnRate = enemySpawnRate;
        InvokeRepeating("SpawnEnemy", 0, spawnTime);

    }

    // Update is called once per frame
    // void Update()
    // {
    //     //spawn
    //     if (curEnemySpawnRate <= 0f)
    //     {
    //         SpawnEnemy();
    //         curEnemySpawnRate = enemySpawnRate;
    //     }
    //     else
    //     {
    //         curEnemySpawnRate -= Time.deltaTime;
    //     }
    // }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, new Vector3(Random.Range(minX, maxX), 15.0762f, transform.position.z), transform.rotation);
    }

    public void endGame()
    {
        Debug.Log("endgame");
        CancelInvoke("SpawnEnemy");
    }

}
