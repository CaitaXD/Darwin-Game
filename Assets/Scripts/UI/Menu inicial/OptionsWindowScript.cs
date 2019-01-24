using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsWindowScript : SelectionMasterScript {
    [SerializeField]
    Text text1,text2,text3,text4;
    string option  = "Menu";
    PlayerInfo _info;
    protected override void Update()
    {
        base.Update();
        _info = GameObject.FindGameObjectWithTag("Info").GetComponent<PlayerInfo>();
    }
    protected override void case1()
    {
      switch (option)
        {
            case ("Menu"):
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    option = "Video";
                    text1.text = "Graphics";
                    text2.text = "Resolution";
                    text3.text = "Shadows";
                    text4.text = " ";
                }
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    iD1.enabled = true;
                   gameObject.SetActive(false);
                }
                    break;
            case ("Video"):

                break;


            case ("Audio"):
          
               
                if (Input.GetKeyDown(KeyCode.A))
                {
                    _info.volume -= 0.1f;

                }
               else  if (Input.GetKeyDown(KeyCode.D))
                {
                    _info.volume += 0.1f;
                }

                break;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && option != "Menu")
        {
            option = "Menu";
            text1.text = "Video";
            text2.text = "Audio";
            text3.text = "Difficulty";
            text4.text = "KeyBinds";
        }
    }


    protected override void case2()
    {
        switch (option)
        {
            case ("Menu"):
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    option = "Audio";
                    text1.text = "Master";
                    text2.text = "Music";
                    text3.text = "Effects";
                    text4.text = " ";

                }
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    iD1.enabled = true;
                    gameObject.SetActive(false);
                }
                break;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && option != "Menu")
        {
            option = "Menu";
            text1.text = "Video";
            text2.text = "Audio";
            text3.text = "Difficulty";
            text4.text = "KeyBinds";
        }
    }


    protected override void case3()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && option != "Menu")
        {
            option = "Menu";
            text1.text = "Video";
            text2.text = "Audio";
            text3.text = "Difficulty";
            text4.text = "KeyBinds";
        }
    }
    protected override void case4()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && option != "Menu")
        {
            option = "Menu";
            text1.text = "Video";
            text2.text = "Audio";
            text3.text = "Difficulty";
            text4.text = "KeyBinds";
        }
    }
    protected override void case5()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && option != "Menu")
        {
            option = "Menu";
            text1.text = "Video";
            text2.text = "Audio";
            text3.text = "Difficulty";
            text4.text = "KeyBinds";
        }
    }


}
