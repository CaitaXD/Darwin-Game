using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayWindowInputs : SelectionMasterScript {

    protected override void case1()
    {

    }
    protected override void case2()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("TutorialJumpandFusion", LoadSceneMode.Single);
        }
    }
   
}
