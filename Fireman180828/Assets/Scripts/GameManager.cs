using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject enemy;
    public GameObject player;
    Collider2D firemanCollider;
    //Collider2D jumperCollider;
    
    //To controll the spawntime and moverDeley
    public float spwanInterval = 5f;
    public float moveDelay = 0.5f;

    //To react with lives
    public LivesController livesController;
    bool gameCointinue = true;

    //To react with Score
    int score;
    public Text scoreText;
    public Text gameOverText;


	// Use this for initialization
	void Start () {
        firemanCollider = player.GetComponentInChildren<Collider2D>();
        //jumperCollider = enemy.GetComponentInChildren<Collider2D>();  
        StartCoroutine(spawnJumper());
   
        livesController.RestorAllLives();

        RestartScore();
        scoreText.text = "";
        gameOverText.text = "";

    }


    IEnumerator spawnJumper()
    { 
        while (gameCointinue)
        {
            NewJumper(moveDelay);
            yield return new WaitForSeconds(spwanInterval);
        }
    }

    void NewJumper(float moveDelay)
    {
            GameObject newJumper = Instantiate(enemy);
            JumperController jumperController = newJumper.GetComponentInChildren<JumperController>();
            jumperController.moveInterval = moveDelay;
            //jumperCollider = newJumper.GetComponentInChildren<Collider2D>();
            //To make access to gameManager in newjumper so that carry out crack() on dangerPosition in JumperController
            newJumper.GetComponentInChildren<JumperController>().gameManager = this; 
    }

    public bool Crack(GameObject jumper)
    {
        if(firemanCollider == null || jumper.GetComponent<Collider2D>() == null)
        {
            Debug.Log("Collider can not found");
        }
        if (firemanCollider.IsTouching(jumper.GetComponent<Collider2D>()))
        {
            Debug.Log("Two touches");
            //Each time to get jumper at danger place add 10 on score
            AddScore();
            return true;
        }
        else
        {
            Debug.Log("RemoveLife is called");
            LoseOneLife();
           // livesController.RemoveLife();
            return false; 
        }     
    }

    //To check whether lives are enough to continue
    public void LoseOneLife()
    {
        if (!livesController.RemoveLife())
        {
            gameCointinue = false;
            GameOver();
        }
            
    }

    public void AddScore()
    {
        score += 10;
        scoreText.text = score.ToString();
    }

    public void RestartScore()
    {
        score = 0;
    }

    public void GameOver()
    {
        
        gameOverText.text = "Game Over!";
    }
}
