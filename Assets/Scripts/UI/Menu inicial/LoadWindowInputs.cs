using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadWindowInputs : SelectionMasterScript {

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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            iD1.enabled = true;
          gameObject.SetActive(false);

        }
    }
    protected override void case3()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            iD1.enabled = true;
           gameObject.SetActive(false);

        }
    }
    protected override void case4()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            iD1.enabled = true;
        gameObject.SetActive(false);

        }
    }
}
