using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blocks : MonoBehaviour
{
    //config parameters
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject BlockSparklesVFX;
   
    [SerializeField] Sprite[] hitSprites;
    //cached reference 
    Level level;
    GameSession gameStatus;
    // AudioSource myAudioSource;

    //State variables
    [SerializeField] int TimesHit;
    public void Start()
    {
        CountBreakableBlocks();
        //WmyAudioSource = GetComponent<AudioSource>();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
        //oyunun başında kaç tane BreakableBlock olduğunu gösterir...
        gameStatus = FindObjectOfType<GameSession>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(gameObject.tag == "Breakable")
        {
            HandleHit();
        }

        //Debug.Log(collision.gameObject.name);
    }

    private void HandleHit()
    {
        TimesHit++;
        int MaxHit = hitSprites.Length + 1;
        if (TimesHit >= MaxHit)
            DestoryBlock();
        else
        {
            ShowHitSprites();
        }
    }

    void DestoryBlock()
    {
        PlayBlockDestroySFX();
        Destroy(gameObject);
        level.BlockDestroyed();
        triggerSparklesVFX();
    }
    void ShowHitSprites()
    {
        int spriteIndex = TimesHit - 1;

        if(hitSprites[spriteIndex]!=null)
        GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
    }
    private void PlayBlockDestroySFX()
    {
        GameSession.instance.AddToScore();
        
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position,0.22f);
        
    }

    private void triggerSparklesVFX()
    {
        GameObject Sparkles = Instantiate(BlockSparklesVFX, transform.position, transform.rotation);
        Destroy(Sparkles, 1f);
    }
}
