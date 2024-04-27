using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Timecontroller : MonoBehaviour
{
    public Text[] timeText;
    public Text gameOverText;
    float time = 10; // 제한 시간 120초
    int min, sec;

    public string nextSceneName; // 전환할 다음 씬의 이름
    public float delay = 12f; // 전환까지의 딜레이 시간


    void Start()
    {
        //제한 시간 02:00
        timeText[0].text = "00";
        timeText[1].text = "10";

        Invoke("SwitchScene", delay);
    }

    void Update()
    {

        
        time -= Time.deltaTime;
        //timeValue = 0;

        min = (int)time / 60;
        sec = ((int)time - min * 60) % 60;

        if (min <= 0 && sec <= 0) //gmae end
        {
            timeText[0].text = 0.ToString();
            timeText[1].text = 0.ToString();
            ShowGameOverText();


        }
        else{
            if (sec >= 60)
            {
                min += 1;
                sec -= 60;
            }
            else
            {
                timeText[0].text = min.ToString();
                timeText[1].text = sec.ToString();
            }
        }
    }

    void ShowGameOverText() //게임 끝났을때 메세지 뛰우는거
    {
        gameOverText.gameObject.SetActive(true);
        gameOverText.text = "Game over";
    }
    void SwitchScene() //씬 전환
    {
        SceneManager.LoadScene("gameoptions");
    }

}
