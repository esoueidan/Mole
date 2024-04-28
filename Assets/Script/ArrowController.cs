using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public string moleTag = "Mole";
    public float distanceFromCamera = 1.0f;

    void Update()
    {
        GameObject mole = GameObject.FindGameObjectWithTag(moleTag);

        if (mole != null)
        {
            // Calculate direction from camera to mole
            Vector3 direction = mole.transform.position - Camera.main.transform.position;
            //direction.y = 0f;

            Quaternion rotation = Quaternion.LookRotation(direction);

            rotation *= Quaternion.Euler(0, 95, 0);

            // Position arrow in front of camera
            transform.position = Camera.main.transform.position + Camera.main.transform.forward * distanceFromCamera;
            transform.rotation = rotation;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
