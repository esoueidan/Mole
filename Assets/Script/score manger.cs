using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoremanger : MonoBehaviour
{
    public Text scoreText;

    void Start()
    {
        // ����� ���� �ҷ�����
        int score = PlayerPrefs.GetInt("Score", 0);

        // UI�� ���� ǥ��
        scoreText.text = " " + score;
    }
}
