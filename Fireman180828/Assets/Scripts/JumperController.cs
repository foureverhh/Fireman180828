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

    //Give player 2 seconds to prepare and jumper to jump every 0.5 second
    IEnumerator JumperShow()
    {
        yield return new WaitForSeconds(reactionTime);
        while (true) {
            yield return new WaitForSeconds(moveInterval);
            transform.position = jumperPos[currentPos].position;
            JumperMove();
         //   Debug.Log("Position in Jumpshow" + currentPos);
       } 
    }

    void JumperMove()
    {
        currentPos++;
        if (currentPos > jumperPos.Count - 1)
            currentPos = 0;
        transform.position = jumperPos[currentPos].position;
       // Debug.Log("Position in JumperMove" + currentPos);
    }
}