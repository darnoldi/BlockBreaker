using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField] float ballX = 0f;
    [SerializeField] float ballY = 0.5f;
    [SerializeField] Paddle paddle;
    [SerializeField] float launchX = 2f;
    [SerializeField] float launchY = 15f;
    [SerializeField] AudioClip[] ballSounds;

    public Boolean isLaunched = false;

    AudioSource myAudioSource;

    Vector2 paddleToBallVector;

    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        paddleToBallVector = new Vector2(ballX, ballY);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLaunched)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
        
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(launchX, launchY);
            isLaunched = true;
        }
    }

    private void LockBallToPaddle()
    {   
        Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
       
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log( collision.gameObject.name.ToString());
        if (isLaunched)
        {
            if (!collision.gameObject.name.ToString().Contains("Block") || !collision.gameObject.name.ToString().Contains("Gem"))
            {
                AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
                myAudioSource.PlayOneShot(clip);
            }
        }
    }
}
