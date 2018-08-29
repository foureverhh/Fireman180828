using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperController : MonoBehaviour
{

    public List<Transform> jumperPos = new List<Transform>();
    int currentPos = 0;
    float reactionTime = 2f;
    float moveInterval = 0.5f;
    // Use this for initialization
    void Start()
    {
        StartCoroutine(JumperShow());
    }

    //Give player 3 seconds to prepare 
    IEnumerator JumperShow()
    {
        yield return new WaitForSeconds(reactionTime);
        while (true) {
            yield return new WaitForSeconds(moveInterval);
            transform.position = jumperPos[currentPos].position;
            JumperMove();
            Debug.Log("Position in Jumpshow" + currentPos);
       }
        
    }

    //Make jumper jumps to next position every second
    void JumperMove()
    {
        currentPos++;
        if (currentPos > jumperPos.Count - 1)
            currentPos = 0;
        transform.position = jumperPos[currentPos].position;
        
        Debug.Log("Position in JumperMove" + currentPos);
    }
}