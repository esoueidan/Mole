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
    public Text ReadyText;
    float time = 70; // ���� �ð� 120��
    int min, sec;

    private int score1 = 0;
    public Text scoreText;

    public string nextSceneName; // ��ȯ�� ���� ���� �̸�
    public float delay = 3f; // ��ȯ������ ������ �ð�


    public Text textToShow;
    public float displayTime = 5f; // �ؽ�Ʈ�� ǥ���� �ð� (��)


    private bool isTimeStopped = false;

    void Start()
    {
        //���� �ð� 02:00
        timeText[0].text = "01";
        timeText[1].text = "10";

        StartCoroutine(ShowTextFor5Seconds());

       
    }

    void Update()
    {
        if (!isTimeStopped)
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

                Invoke("SwitchScene", delay);
            }
            else
            {
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

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) //��ġ������ ��°�
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {

                if (hit.collider.CompareTag("Mole")) //tag ��������ߵ�
                {
                    if ((!isTimeStopped))
                    {
                        if (min <= 0 && sec <= 0)
                        {
                            UpdateScoreUI();

                        }
                        else
                        {
                            score1++;
                            UpdateScoreUI();
                        }
                    }
                    else
                    {
                        if (min <= 0 && sec <= 0)
                        {
                            UpdateScoreUI();

                        }
                        else
                        {
                            score1++;
                            UpdateScoreUI();
                        }
                    }
                }
                else if (hit.collider.CompareTag("Princess")) //tag ��������ߵ�
                {

                    if ((!isTimeStopped))
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
                    else
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

                }
                else if (hit.collider.CompareTag("Bomb")) //tag ��������ߵ�
                {

                    if ((!isTimeStopped))
                    {
                        if (min <= 0 && sec <= 0)
                        {
                            UpdateScoreUI();

                        }
                        else
                        {
                            score1 -=3;
                            UpdateScoreUI();
                        }
                    }
                    else
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
                else if (hit.collider.CompareTag("Hourglass")) // �ð��� ���ߴ� ������Ʈ�� ��ġ�ߴٸ�
                {
                    StopTime(); // �ð� ���߱�
                    StartCoroutine(ResumeTimeAfterDelay(5f)); // 5�� �Ŀ� �ð� �ٽ� ����

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
    void StopTime()
    {
        isTimeStopped = true;
    }
    IEnumerator ResumeTimeAfterDelay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        isTimeStopped = false;
    }

    IEnumerator ShowTextFor5Seconds()
    {
        // "5�� ����" �ؽ�Ʈ�� Ȱ��ȭ
        ReadyText.gameObject.SetActive(true);
        ReadyText.text = "ARE YOU READY?";

        // 5�� ���
        yield return new WaitForSeconds(2f);

        // "5�� ����" �ؽ�Ʈ�� ��Ȱ��ȭ
        ReadyText.gameObject.SetActive(false);
    }

}