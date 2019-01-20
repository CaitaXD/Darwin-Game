using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputsMenuInicial :SelectionMasterScript {

 protected override void case1 ()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            window1.SetActive(true);
            stopNavegation = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            window1.SetActive(false);
            stopNavegation = false;
        }
    }
    protected override void case2()
    {

    }
    protected override void case3()
    {

    }
    protected override void case4()
    {

    }
    protected override void case5()
    {

    }
}
