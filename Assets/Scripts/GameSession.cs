using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int currentScore = 0;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] int currentLives = 3; 


    //AWAKE happens first in init

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = currentScore.ToString();
        livesText.text = "Lives:" + currentLives.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddScore(int score)
    {
        currentScore = currentScore + score;
        scoreText.text = currentScore.ToString();
    }

    public int LoseLife()
    {
        currentLives--;
        
        if (currentLives <= 0)
        {
            SceneManager.LoadScene("Game Over");
        }
        livesText.text = "Lives:" + currentLives.ToString();
        return currentLives;
    }

    public void ResetGame()
    {
        Destroy(gameObject);
       // currentLives = 3;
    }

}
