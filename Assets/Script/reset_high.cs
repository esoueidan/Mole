using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reset_high : MonoBehaviour
{ 
    public void ResetHighScoreButton()  // PlayerPrefs���� �ְ� ���� �ʱ�ȭ
    {
        PlayerPrefs.SetInt("HighScore", 0);
        PlayerPrefs.Save();
    }
}
