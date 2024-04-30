using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTouch1 : MonoBehaviour
{
    public AudioClip soundClip; // 재생할 소리 클립
    private bool hasPlayedSound = false;

    void Update()
    {
        // 터치 이벤트가 감지되었는지 확인
        if (Input.touchCount > 0)
        {
            // 첫 번째 터치 이벤트를 가져옴
            Touch touch = Input.GetTouch(0);

            // 터치 상태가 터치로 시작하거나 터치 중인 경우
            if ((touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary) && !hasPlayedSound)
            {
                // 터치한 위치에서 소리 재생
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                if (Physics.Raycast(ray, out hit))
                {
                    
                    if (hit.collider.gameObject.CompareTag("Mole"))
                    {
                        
                        AudioSource.PlayClipAtPoint(soundClip, hit.point);
                        hasPlayedSound = true; 
                    }
                    
                }
            }
        }
        else
        {
            // 터치가 없는 경우 다시 소리를 재생할 수 있도록 플래그를 리셋
            hasPlayedSound = false;
        }
    }
}
