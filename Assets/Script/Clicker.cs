using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class Clicker : MonoBehaviour
{
    private ARRaycastManager raycastManager;
    public GameObject Mole;
    public GameObject Princess;
    public GameObject Bomb;
    public Spawner spawner;

    public AudioClip sound1;
    public AudioClip sound2;
    public AudioClip sound3;
    void awake(){
        raycastManager = GetComponent<ARRaycastManager>();
    }
    void Update()
    {
        
        if (Input.touchCount >0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    
                    if (hit.collider.gameObject.CompareTag("Mole"))
                    {
                        spawner.timer = spawner.spawnInterval;
                        Destroy(hit.collider.gameObject);
                        AudioSource.PlayClipAtPoint(sound1, hit.point);

                    }
                    if (hit.collider.gameObject.CompareTag("Princess"))
                    {
                        spawner.timer = spawner.spawnInterval;
                        Destroy(hit.collider.gameObject);
                        AudioSource.PlayClipAtPoint(sound2, hit.point);

                    }
                    if (hit.collider.gameObject.CompareTag("Bomb"))
                    {
                        spawner.timer = spawner.spawnInterval;
                        Destroy(hit.collider.gameObject);
                        AudioSource.PlayClipAtPoint(sound3, hit.point);
                    }

                    Debug.DrawLine(ray.origin, hit.point, Color.red, 1.0f);
                }
                else
                {
                    Debug.DrawRay(ray.origin, ray.direction * 10, Color.red, 1.0f);
                }
            }
        }
    }
}


