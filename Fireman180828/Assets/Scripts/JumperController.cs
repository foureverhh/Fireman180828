using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperController : MonoBehaviour
{
    //Collider istouching need a reaction time of a frame then gameManager is needed to wait for one frame
    [HideInInspector]
    public GameManager gameManager;

    public List<Transform> jumperPos = new List<Transform>();
    int currentPos = 0;

    [HideInInspector]
    public float moveInterval;
    // Use this for initialization
    void Start()
    {
        StartCoroutine(JumperShow(moveInterval));
    }

    //jumper to jump every moveInterval seconds
    IEnumerator JumperShow(float moveInterval)
    {
        while (true) {
            yield return new WaitForSeconds(moveInterval);
            transform.position = jumperPos[currentPos].position;
           // yield return new WaitForSeconds(moveInterval);
            StartCoroutine(JumperMove());
         //   Debug.Log("Position in Jumpshow" + currentPos);
       } 
    }

    IEnumerator JumperMove()
    {
        // if(currentPos < jumperPos.Count - 1)
        // {
        //     currentPos++;
        //     transform.position = jumperPos[currentPos].position;
        // }
        //yield return null;
        currentPos++;
        if (currentPos > jumperPos.Count - 1)
        {
            //When jumper finished all positions, then destroy its parent
            Destroy(transform.parent.gameObject);
            currentPos = 0;
        }
        transform.position = jumperPos[currentPos].position;
        //Give one frame to get the result of gameManager.Crack()
        yield return null;
        if (jumperPos[currentPos].GetComponent<DangerPosition>().danger)
        {
            if (gameManager.Crack(gameObject))
            {
                Debug.Log("Get jumper");
            }
            else
                Debug.Log("Lose jumper");
        }
        // Debug.Log("Position in JumperMove" + currentPos);
    }
}