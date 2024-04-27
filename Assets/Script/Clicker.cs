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
                       //Debug.Log("Mole was hit!");
                        Destroy(hit.collider.gameObject);
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


