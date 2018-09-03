using UnityEngine;

public class LivesController : MonoBehaviour {

    [SerializeField]
    private int lives = 4;
    public float distance = 1f;

    private void Start()
    {
        for(int i = 1; i < lives; i++)
        {
            GameObject newheart = Instantiate(transform.GetChild(0).gameObject);
            newheart.transform.SetParent(transform);
            Vector3 newHeartPos = newheart.transform.position;
            newHeartPos.x += (i * distance);
            newheart.transform.position = newHeartPos;
        }
    }

    public bool RemoveLife()
    {
        Debug.Log("RemoveLife is called in livesController");
        lives--;
        transform.GetChild(lives).gameObject.SetActive(false);
        Debug.Log("Life now is: " + lives);
        if (lives == 0)
            return false;
        return true;
    }

    public void RestorAllLives()
    {
        foreach (Transform child in transform)
            child.gameObject.SetActive(true);
    }
}
