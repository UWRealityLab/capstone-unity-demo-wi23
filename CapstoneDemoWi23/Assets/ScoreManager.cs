using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public int score = 0;
    
    public void updateScore(int scoreChange)
    {
        score += scoreChange;
        scoreText.text = "Score: " + score;
    }
}
