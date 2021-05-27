using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public Text endScore;
    public Text endloseScore;

    public void AddScore(float points)
    {
        float timeNow = Time.realtimeSinceStartup;
        float timeAchieved = float.Parse(scoreText.text);
        timeNow += (timeAchieved * 1.5f + points);
        scoreText.text = timeNow.ToString();
        endScore.text = "Score: " + scoreText.text;
        endloseScore.text = "Score: " + scoreText.text;
    }
   
}
