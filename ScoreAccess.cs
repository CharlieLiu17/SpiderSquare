using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreAccess : MonoBehaviour
{
    public TextMeshProUGUI scoreboard;

    // Update is called once per frame
    void Update()
    {
        scoreboard.text = ScoreBoard.scoreCounter.ToString();
    }
}
