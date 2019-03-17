using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioReader : MonoBehaviour {
    public float sceneMusic = 0.5f, batlleSounds = 0.5f, ambientMusic = 0.5f;
    public float enemySpeedMod, enemyDamageMod, enemyRangeMod;
    public int DifficultyLevel= 2;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        Data data = SaveSystem.LoadAudioData();
        sceneMusic = data.sceneMusic;
        batlleSounds = data.batlleSounds;
        AudioListener.volume = data.msterVolume;
        ambientMusic = data.ambientMusic;
        DifficultyLevel = data.DiffycultyLevel;
        enemySpeedMod = data.enemySpeedMod;
        enemyRangeMod = data.enemyRangeMod;
        enemyDamageMod = data.enemyDamageMod;

        switch (DifficultyLevel)
        {
            case (1):
                Easy();
                break;
            case (2):
                Normal();
                break;
            case (3):
                Hard();
                break;
            case (4):
                Insane();
                break;

        }

    }
    
    public void Easy()
    {
        enemyDamageMod = 0.75f; enemyRangeMod = 0.75f; enemySpeedMod = 0.75f;
    }
    public void Normal()
    {
        enemyDamageMod = 1f; enemyRangeMod = 1f; enemySpeedMod = 1f;
    }
    public void Hard()
    {
        enemyDamageMod = 1.5f; enemyRangeMod = 1.5f; enemySpeedMod = 1.5f;
    }
    public void Insane()
    {
        enemyDamageMod = 3f; enemyRangeMod = 2.5f; enemySpeedMod = 2f;
    }
}
