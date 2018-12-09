using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitFPS : MonoBehaviour {

    public int target = 60;

    private void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = target;
    }

    private void Update()
    {
        if(Application.targetFrameRate != target)
        {
            Application.targetFrameRate = target;
        }
    }
}
