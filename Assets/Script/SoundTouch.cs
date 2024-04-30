using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTouch1 : MonoBehaviour
{
    public AudioClip soundClip; // ����� �Ҹ� Ŭ��
    private bool hasPlayedSound = false;

    void Update()
    {
        // ��ġ �̺�Ʈ�� �����Ǿ����� Ȯ��
        if (Input.touchCount > 0)
        {
            // ù ��° ��ġ �̺�Ʈ�� ������
            Touch touch = Input.GetTouch(0);

            // ��ġ ���°� ��ġ�� �����ϰų� ��ġ ���� ���
            if ((touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary) && !hasPlayedSound)
            {
                // ��ġ�� ��ġ���� �Ҹ� ���
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
            // ��ġ�� ���� ��� �ٽ� �Ҹ��� ����� �� �ֵ��� �÷��׸� ����
            hasPlayedSound = false;
        }
    }
}
