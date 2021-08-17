using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptBlock : MonoBehaviour
{
    // config params
    [SerializeField] int blockScore = 1;
    [SerializeField] int maxHits;
    [SerializeField] AudioClip blockBreakingSound;
    [SerializeField] GameObject blockDestroyVFX;
    [SerializeField] Sprite[] hitSprites;


    //cached references
    Level level;
    GameSession gameStatus;

    //state variables
    [SerializeField] int timesHit;    //TODO only serialized for debug

    private void Start()
    {
        gameStatus = FindObjectOfType<GameSession>();

        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timesHit++;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
    }

    private void DestroyBlock()
    {
        PlayBlockBreakAudio();
        Destroy(gameObject);
        TriggerBlockDestroyVFX();
        level.SubtractDestroyedBlock();
    }

    private void PlayBlockBreakAudio()
    {
        AudioSource.PlayClipAtPoint(blockBreakingSound, Camera.main.transform.position);
        gameStatus.AddScore(blockScore);
    }

    private void TriggerBlockDestroyVFX ()
    {
        GameObject sparkles = Instantiate(blockDestroyVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}
