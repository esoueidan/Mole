using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.UI;


public class effect_sound : MonoBehaviour
{
    public AudioSource audioSource; // �Ҹ��� ����ϴ� AudioSource
    public AudioClip soundClip; // ����� �Ҹ� Ŭ��
    public Button increaseVolumeButton; // ������ �ø��� ��ư
    public Button decreaseVolumeButton; // ������ ���̴� ��ư

    public float volumeChangeAmount = 0.1f; // ������ ������ ��


    // �δ��� ������� �Ҹ��� ���;� �Ǵϱ� ���� ���ǹ��� ������ ��.

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
