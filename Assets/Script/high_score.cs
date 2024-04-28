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
        // ���� ������ �ְ� ���� �ҷ�����
        int currentScore = PlayerPrefs.GetInt("Score", 0);
        int highScore = PlayerPrefs.GetInt("HighScore", 0);


        // �ְ� ������ ���ŵǸ� �����ϰ� UI�� ǥ��
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

        // �ְ� ���� ǥ��
        highScoreText.text = " " + highScore;
    }
}
