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
    public Button soundOnButton; // �Ҹ��� �Ѵ� ��ư
    public Button soundOffButton; // �Ҹ��� ���� ��ư


    private bool isSoundOn = true;
    private bool isPlaying = false;

    public float volumeChangeAmount = 0.1f; // ������ ������ ��

    void Start()
    {
        soundOnButton.onClick.AddListener(TurnSoundOn);
        soundOffButton.onClick.AddListener(TurnSoundOff);


        UpdateButtonVisibility();

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
        isSoundOn = !isSoundOn;
        if (isSoundOn)
        {
            audioSource.PlayOneShot(soundClip);
        }
        else
        {
            audioSource.Stop();
        }
        UpdateButtonVisibility();
    }

    void TurnSoundOn()
    {
        isSoundOn = true;
        audioSource.PlayOneShot(soundClip);
        soundOnButton.gameObject.SetActive(true);
        soundOffButton.gameObject.SetActive(false);
    }

    // �Ҹ��� ���� �Լ�
    void TurnSoundOff()
    {
        isSoundOn = false;
        audioSource.Stop();
        soundOnButton.gameObject.SetActive(true);
        soundOffButton.gameObject.SetActive(false);
    }

    void UpdateButtonVisibility()
    {
        soundOnButton.gameObject.SetActive(!isSoundOn);
        soundOffButton.gameObject.SetActive(isSoundOn);
    }
}
