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
    public Button soundButton;
    private bool isSoundOn = true;


    public float volumeChangeAmount = 0.1f; // 볼륨을 변경할 양

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
        // 소리를 켜거나 끔
        isSoundOn = !isSoundOn;

        // 소리 상태에 따라 버튼 텍스트 변경
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
