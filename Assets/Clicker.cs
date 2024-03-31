using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Debug.Log("oui oui");
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    // Check if the raycast hits this object
                    if (hit.collider.gameObject == gameObject)
                    {
                        Destroy(gameObject);
                    }

                    // Draw a line to visualize the raycast
                    Debug.DrawLine(ray.origin, hit.point, Color.red, 1.0f);
                }
                else
                {
                    // Draw a line in the direction of the raycast if it didn't hit anything
                    Debug.DrawRay(ray.origin, ray.direction * 10, Color.red, 1.0f);
                }
            }
        }
    }
}


