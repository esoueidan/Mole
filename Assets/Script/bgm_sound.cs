using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.UI;


public class bgm_sound : MonoBehaviour
{
    public AudioSource audioSource; // 소리를 재생하는 AudioSource
    public AudioClip soundClip; // 재생할 소리 클립
    public Button increaseVolumeButton; // 볼륨을 늘리는 버튼
    public Button decreaseVolumeButton; // 볼륨을 줄이는 버튼
    public Button soundOnButton; // 소리를 켜는 버튼
    public Button soundOffButton; // 소리를 끄는 버튼


    private bool isSoundOn = true;
    private bool isPlaying = false;

    public float volumeChangeAmount = 0.1f; // 볼륨을 변경할 양

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

    // 소리를 끄는 함수
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
