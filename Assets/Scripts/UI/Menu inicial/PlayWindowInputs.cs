using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayWindowInputs : SelectionMasterScript {

    protected override void case1()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            iD1.enabled = true;
            gameObject.SetActive(false);

        }
    }
    protected override void case2()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("TutorialJumpandFusion", LoadSceneMode.Single);
        } else if (Input.GetKeyDown(KeyCode.Escape))
        {
            iD1.enabled = true;
          gameObject.SetActive(false);
          
        }
    }
   
}
