using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public string moleTag = "Mole";

    void Update()
    {
        GameObject mole = GameObject.FindGameObjectWithTag(moleTag);

        if (mole != null)
        {
            Vector3 direction = mole.transform.position - Camera.main.transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = rotation;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}

