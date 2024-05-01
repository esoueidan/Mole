using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenechage : MonoBehaviour
{
    // Start is called before the first frame update
    public void MainSceneChange()
    {
        SceneManager.LoadScene("MainMenu");

    }
    
    public void RestartSceneChange()
    {
        SceneManager.LoadScene("Mode");
    }

    public void InstructSceneChange()
    {
        SceneManager.LoadScene("Instructions");
    }


}
