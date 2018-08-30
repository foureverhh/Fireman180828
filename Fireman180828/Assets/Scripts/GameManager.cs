using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject enemy;
    public GameObject player;
    Collider2D firemanCollider;
    Collider2D jumperCollider;

	// Use this for initialization
	void Start () {
        firemanCollider = enemy.GetComponentInChildren<Collider2D>();
        jumperCollider = player.GetComponentInChildren<Collider2D>();  
	}
	
	// Update is called once per frame
	void Update () {
        Crack();
	}

    void Crack()
    {
        if (firemanCollider == null || jumperCollider == null)
            Debug.Log("Collider can not found");
        else if (firemanCollider.IsTouching(jumperCollider))
            Debug.Log("Two touches");
    }

}
