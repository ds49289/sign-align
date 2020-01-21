using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    private int score;
    // Update is called once per frame
    void Update()
    {
        score = PlayerPrefs.GetInt("Score");
        textMesh.SetText(score.ToString());
    }
}
