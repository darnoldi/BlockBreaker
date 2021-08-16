using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public void LoadNextScene()
    {
        FindObjectOfType<GameSession>().ResetGame();
        
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadStartScene()
    {
        
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {

        Application.Quit();
    }
}
