using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCollision : MonoBehaviour
{
    public ScoreScript scoreRef;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider col)
    {
         if (col.gameObject.tag == "EndCube")
        {
            Debug.Log("pogodili smo kocku");
            if (scoreRef.isWinner)
            {
                PlayerPrefs.SetInt("Score", scoreRef.score);
                SceneManager.LoadScene("Winner");
            }
            else
            {
                PlayerPrefs.SetInt("Score", scoreRef.score);
                SceneManager.LoadScene("Loser");
            }
        }
    }
}
