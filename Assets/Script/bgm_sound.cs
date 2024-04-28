using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.UI;


public class bgm_sound : MonoBehaviour
{
    public AudioSource audioSource; // �Ҹ��� ����ϴ� AudioSource
    public AudioClip soundClip; // ����� �Ҹ� Ŭ��
    public Button increaseVolumeButton; // ������ �ø��� ��ư
    public Button decreaseVolumeButton; // ������ ���̴� ��ư
    public Button soundButton;
    private bool isSoundOn = true;


    public float volumeChangeAmount = 0.1f; // ������ ������ ��

    void Start()
    {

        soundButton.onClick.AddListener(ToggleSound);
        increaseVolumeButton.onClick.AddListener(IncreaseVolume);
        decreaseVolumeButton.onClick.AddListener(DecreaseVolume);
    }

    void IncreaseVolume()
    {
        
        audioSource.volume = Mathf.Clamp01(audioSource.volume + volumeChangeAmount);
    }

    void DecreaseVolume()
    {
        
        audioSource.volume = Mathf.Clamp01(audioSource.volume - volumeChangeAmount);
    }



    void ToggleSound()
    {
        // �Ҹ��� �Ѱų� ��
        isSoundOn = !isSoundOn;

        // �Ҹ� ���¿� ���� ��ư �ؽ�Ʈ ����
        if (isSoundOn)
        {
            audioSource.PlayOneShot(soundClip);
        }
        else
        {

            audioSource.Stop();
        }
    }
}
