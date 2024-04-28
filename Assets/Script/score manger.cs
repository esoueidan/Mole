using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoremanger : MonoBehaviour
{
    public Text scoreText;

    void Start()
    {
        // 저장된 점수 불러오기
        int score = PlayerPrefs.GetInt("Score", 0);

        // UI에 점수 표시
        scoreText.text = " " + score;
    }
}
