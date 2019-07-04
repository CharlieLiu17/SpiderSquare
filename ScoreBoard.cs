using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    public static int scoreCounter;
    private TextMeshProUGUI scoreboard;
    // Start is called before the first frame update
    void Start()
    {
        scoreCounter = 0;
        scoreboard = GetComponent<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {
        scoreboard.text = scoreCounter.ToString();
        if (scoreCounter > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", ScoreBoard.scoreCounter);
        }
    }
}
