using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class high_score : MonoBehaviour
{
    //public Text currentScoreText;
    public Text highScoreText;

    void Start()
    {
        // 현재 점수와 최고 점수 불러오기
        int currentScore = PlayerPrefs.GetInt("Score", 0);
        int highScore = PlayerPrefs.GetInt("HighScore", 0);


        // 최고 점수가 갱신되면 저장하고 UI에 표시
        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }
        else if (highScore == 0)
        {
            highScoreText.text = "0";
        }

        // 최고 점수 표시
        highScoreText.text = " " + highScore;
    }
}
