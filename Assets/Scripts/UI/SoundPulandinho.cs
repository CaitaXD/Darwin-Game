using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPulandinho : MonoBehaviour {

    public AudioSource loadingSound;

    //Som de pulo do loading
    void Pulandinho()
    {
        loadingSound.Play();
    }
}
