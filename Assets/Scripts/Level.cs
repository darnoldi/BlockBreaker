using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{

    [SerializeField] int breakableBlocks;
    [SerializeField] Ball ball;
    [SerializeField] Paddle paddle;
 
    SceneLoader sceneLoader;
    GameSession gameSession;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        gameSession = FindObjectOfType<GameSession>();
    }

    public void CountBlocks ()
    {
        breakableBlocks++;
        
    }

    public void SubtractDestroyedBlock()
    {
        breakableBlocks--;
        if (breakableBlocks <= 0 )
        {
            sceneLoader.LoadNextScene();
        }
    }


    public void LoseLife ()
    {
        if (gameSession.LoseLife() > 0)
        {
            paddle.Reset();
            ball.Reset();
        }
      
    }
}
