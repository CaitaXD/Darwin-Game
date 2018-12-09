using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingSceen : MonoBehaviour {
    float timerLoading;
    bool loading;
    [SerializeField]
    GameObject loadingScreen;
    public AudioSource sceneMusic;
    public AudioSource loadingSound;

    // Use this for initialization
    void Start ()
    {
        loading = true;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (loading)
        {
            timerLoading += Time.deltaTime;
        }
        if (timerLoading > 5)
        {
            loading = false;
            timerLoading = 0;
            sceneMusic.Play();
        }
        if (loading == false)
        {
            loadingScreen.SetActive(false);
        }
    }
}
