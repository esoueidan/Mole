using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenechage : MonoBehaviour
{
    // Start is called before the first frame update
    public void suboptionSceneChange()
    {
        SceneManager.LoadScene("suboption");

    }
    
    public void gameoptionSceneChange()
    {
        SceneManager.LoadScene("gameoptions");
    }
    

}
