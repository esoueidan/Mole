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
    float time = 70; // ���� �ð� 120��
    int min, sec;

    private int score1 = 0;
    public Text scoreText;

    public string nextSceneName; // ��ȯ�� ���� ���� �̸�
    public float delay = 72f; // ��ȯ������ ������ �ð�

   

    void Start()
    {
        //���� �ð� 02:00
        timeText[0].text = "01";
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


        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) //��ġ������ ��°�
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {

                if (hit.collider.CompareTag("Mole")) //tag ��������ߵ�
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
                else if (hit.collider.CompareTag("Princess")) //tag ��������ߵ�
                {

                    if (min <= 0 && sec <= 0)
                    {
                        UpdateScoreUI();

                    }
                    else
                    {
                        score1 += 5;
                        UpdateScoreUI();
                    }

                }
                else if (hit.collider.CompareTag("Bomb")) //tag ��������ߵ�
                {

                    if (min <= 0 && sec <= 0)
                    {
                        UpdateScoreUI();

                    }
                    else
                    {
                        score1 -= 3;
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
