using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void GameStart()
    {
        SceneManager.LoadScene("240206_Animation", LoadSceneMode.Additive);
    }
    
    public void GameStartHomework()
    {
        SceneManager.LoadScene("240206_Homework", LoadSceneMode.Single);
    }

    public void GoTitle()
    {
        SceneManager.LoadScene("240206_homeworkTitle");
    }

    public void GoManual()
    {
        SceneManager.LoadScene("Manual");
    }


}
