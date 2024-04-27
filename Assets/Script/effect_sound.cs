using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.UI;


public class effect_sound : MonoBehaviour
{
    public AudioSource audioSource; // 소리를 재생하는 AudioSource
    public AudioClip soundClip; // 재생할 소리 클립
    public Button increaseVolumeButton; // 볼륨을 늘리는 버튼
    public Button decreaseVolumeButton; // 볼륨을 줄이는 버튼

    public float volumeChangeAmount = 0.1f; // 볼륨을 변경할 양


    // 두더지 잡았을때 소리가 나와야 되니깐 따로 조건문을 만들어야 됨.

    void Start()
    {
        
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

}
