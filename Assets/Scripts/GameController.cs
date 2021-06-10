using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text scoreText;
    public Text totalScoreText;
    private int score;
    public GameObject gate;
    // public spawnScript spawn;

    void Start (){
        score = 0;
        UpdateScore (); 
        if (gate.activeInHierarchy){
             gate.SetActive(false);
        }
         StartCoroutine(LateCall());
    }

    public void AddScore(){
        score+=10;
        UpdateScore();
    }

    void UpdateScore (){
        scoreText.text = "" + score;
        totalScoreText.text = "Total Score : " + score;
    }

    IEnumerator LateCall(){
         yield return new WaitForSeconds(15f);
         gate.SetActive(true);
        //  spawn.endGame();
     }

}
