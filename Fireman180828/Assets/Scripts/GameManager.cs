using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject enemy;
    public GameObject player;
    Collider2D firemanCollider;
    //Collider2D jumperCollider;
    
    //To controll the spawntime and moverDeley
    public float spwanInterval = 5f;
    public float moveDelay = 0.5f;

	// Use this for initialization
	void Start () {
        firemanCollider = player.GetComponentInChildren<Collider2D>();
        //jumperCollider = enemy.GetComponentInChildren<Collider2D>();  
        StartCoroutine(spawnJumper());
    
	}
	
	// Update is called once per frame
	//void Update () {
    //    Crack();
	//}

    IEnumerator spawnJumper()
    { 
        while (true)
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
            return true; 
        }
        else
            return false; 
    }
}
