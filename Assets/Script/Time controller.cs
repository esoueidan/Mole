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
    float time = 10; // ���� �ð� 120��
    int min, sec;

    private int score1 = 0;
    public Text scoreText;

    public string nextSceneName; // ��ȯ�� ���� ���� �̸�
    public float delay = 12f; // ��ȯ������ ������ �ð�

   

    void Start()
    {
        //���� �ð� 02:00
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


        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) //��ġ������ ��°�
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {

                if (hit.collider.CompareTag("ScoreObject")) //tag ��������ߵ�
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

    void ShowGameOverText() //���� �������� �޼��� �ٿ�°�
    {
        gameOverText.gameObject.SetActive(true);
        gameOverText.text = "time out";
    }
    void SwitchScene() //�� ��ȯ
    {
        SceneManager.LoadScene("gameoption");
    }
    private void UpdateScoreUI()// ����
    {
        scoreText.text = "Score: " + score1;
    }
    private void OnDestroy()
    {
        // ���� ���� �� ���� ����
        PlayerPrefs.SetInt("Score", score1);
        PlayerPrefs.Save();
    }

    
}
