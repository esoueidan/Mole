using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reset_high : MonoBehaviour
{ 
    public void ResetHighScoreButton()  // PlayerPrefs에서 최고 점수 초기화
    {
        PlayerPrefs.SetInt("HighScore", 0);
        PlayerPrefs.Save();
    }
}
