using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int score;

    // Update is called once per frame
    void Update()
    {
        score = (int)Time.timeSinceLevelLoad;
        scoreText.text = "Score: "  + score.ToString();
    }
}
