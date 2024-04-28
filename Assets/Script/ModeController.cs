using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ModeController : MonoBehaviour
{
    public void LoadGame (string input)
    {
        if(input == "Easy")
        {
            DifState.difficulty = 8;
        }
        if (input == "Normal")
        {
            DifState.difficulty = 6;
        }
        if (input == "Hard")
        {
            DifState.difficulty = 4;
        }

        SceneManager.LoadScene("Test");
    }
}
