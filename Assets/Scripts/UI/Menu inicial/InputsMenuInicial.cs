using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputsMenuInicial :SelectionMasterScript {
    [SerializeField]
    protected GameObject window1, window2, window3, window4, window5;

    protected override void case1 ()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            window1.SetActive(true);
            iD1.enabled = false;
          
        } 
    }
    protected override void case2()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            window2.SetActive(true);
            iD1.enabled = false;
            

        }    
    }
    protected override void case3()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            window3.SetActive(true);
            iD1.enabled = false;


        }
    }
    protected override void case4()
    {

    }
    protected override void case5()
    {

    }
}
