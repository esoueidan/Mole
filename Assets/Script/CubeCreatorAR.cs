using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCreatorAR : MonoBehaviour
{
    public GameObject cubePrefab; // Assign the cube prefab in the Unity Editor

    void Update()
    {
        // Check for touch input
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            // Get the position of the touch in world space
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

            // Create a cube at the touch position
            Instantiate(cubePrefab, touchPosition, Quaternion.identity);
        }
    }
}
