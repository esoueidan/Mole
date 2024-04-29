using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;


public class Timecontroller : MonoBehaviour
{
    public Text[] timeText;
    public Text gameOverText;
    float time = 10; // 제한 시간 120초
    int min, sec;

    private int score1 = 0;
    public Text scoreText;

    public string nextSceneName; // 전환할 다음 씬의 이름
    public float delay = 12f; // 전환까지의 딜레이 시간

   

    void Start()
    {
        //제한 시간 02:00
        timeText[0].text = "01";
        timeText[1].text = "00";

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


        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) //터치했을때 잡는거
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {

                if (hit.collider.CompareTag("ScoreObject")) //tag 설정해줘야됨
                {
                                
                    if (min <= 0 && sec <= 0) 
                    {
                        UpdateScoreUI();

                    }else 
                    {
                        score1++;
                        UpdateScoreUI();
                    }
                                      
                }
            }
        }

    }

    void ShowGameOverText() //게임 끝났을때 메세지 뛰우는거
    {
        gameOverText.gameObject.SetActive(true);
        gameOverText.text = "time out";
    }
    void SwitchScene() //씬 전환
    {
        SceneManager.LoadScene("gameoption");
    }
    private void UpdateScoreUI()// 점수
    {
        scoreText.text = "Score: " + score1;
    }
    private void OnDestroy()
    {
        // 게임 종료 시 점수 저장
        PlayerPrefs.SetInt("Score", score1);
        PlayerPrefs.Save();
    }

    
}
