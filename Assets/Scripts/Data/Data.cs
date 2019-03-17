using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Data {

    public string stage;
    public float life;
    public int[] fusionId;
    public int mineralNumber;
    public float sceneMusic, batlleSounds, ambientMusic;
    public float msterVolume;
    public int DiffycultyLevel =2;
    public float enemySpeedMod, enemyDamageMod, enemyRangeMod;

    public Data (PlayerInfo info)
    {
        life = info.life;
        fusionId = info.id.ToArray();
        mineralNumber = info.number;

    }
    public Data (AudioReader audio)
    {
        sceneMusic = audio.sceneMusic;
        batlleSounds = audio.batlleSounds;
        ambientMusic = audio.ambientMusic;
        msterVolume = AudioListener.volume;
        DiffycultyLevel = audio.DifficultyLevel;
        enemySpeedMod = audio.enemySpeedMod;
        enemyRangeMod = audio.enemyRangeMod;
        enemyDamageMod = audio.enemyDamageMod;

    }

}
