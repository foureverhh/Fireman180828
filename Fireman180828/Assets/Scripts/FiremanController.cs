using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiremanController : MonoBehaviour {

    public List<Transform> firemanPos = new List<Transform>();

    int currentPos = 0;

    void OnEnable()
    {
        Input.OnLeftPressed += Move_ToLeft;
        Input.OnRightPressed += Move_ToRight;
    }

    void OnDisable()
    {
        Input.OnLeftPressed -= Move_ToLeft;
        Input.OnRightPressed -= Move_ToRight;
    }

    private void Start()
    {
        transform.position = firemanPos[currentPos].position;
    }

    void Move_ToLeft()
    {

        currentPos--;
        if (currentPos < 0)
            currentPos = firemanPos.Count - 1;
       //Debug.Log("curretPos in Left: " + currentPos);
        transform.position = firemanPos[currentPos].position;  
    }

    void Move_ToRight()
    {
        currentPos++;
        if (currentPos > firemanPos.Count - 1)
            currentPos = 0;
        //Debug.Log("curretPos in right: " + currentPos);
        transform.position = firemanPos[currentPos].position;
    }
}
