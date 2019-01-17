using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlay : MonoBehaviour {
    //Quase todos os sons de ataque
    public AudioSource Harden;
    public AudioSource Roll;
    public AudioSource Woosh;
    public AudioSource Crawl;
    public AudioSource Bite;
    public AudioSource BatHit;
    public AudioSource BatFlap;
    public AudioSource healingsound;

    void HardenPlay()
    {
        Harden.Play();
    }
    void RollPlay()
    {
        Roll.Play();
    }
    void WooshPlay()
    {
        Woosh.Play();
    }
    void CrawlPlay()
    {
        Crawl.Play();
    }
    void BitePlay()
    {
        Bite.Play();
    }
    void BatHitPlay()
    {
        BatHit.Play();
    }
    void BatFlapPlay()
    {
        BatFlap.Play();
    }
    void healingSound()
    {
        healingsound.Play();
    }
}
