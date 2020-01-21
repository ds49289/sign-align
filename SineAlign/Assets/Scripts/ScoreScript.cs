using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreScript : MonoBehaviour
{
    public bool isWinner = false;
    public int minToWin = 200;
    [SerializeField]
    private TextMeshProUGUI scoreTextMeshPro;

    [SerializeField]
    private int collectableScoreIncrease = 10;

    public int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreTextMeshPro.SetText("Score: " + score);
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Collectable")
        {
            score += collectableScoreIncrease;
            if (score >= minToWin)
            {
                isWinner = true;
                Debug.Log("ISWINNER JE TRUE");
            }
        }
    }
}
