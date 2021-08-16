using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptBlock : MonoBehaviour
{
    [SerializeField] int blockScore = 1;
    [SerializeField] AudioClip blockBreakingSound;
    [SerializeField] GameObject blockDestroyVFX;

    Level level;
    GameSession gameStatus;

    private void Start()
    {
        level = FindObjectOfType<Level>();
        gameStatus = FindObjectOfType<GameSession> ();
        level.CountBreakableBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyBlock();
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
        Destroy(sparkles, 120);
    }
}
