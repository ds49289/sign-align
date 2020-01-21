using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreTextMeshPro;

    [SerializeField]
    private int collectableScoreIncrease = 10;

    private int score = 0;
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
        }
    }
}
