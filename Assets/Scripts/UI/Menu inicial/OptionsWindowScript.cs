using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class OptionsWindowScript : SelectionMasterScript {
    [SerializeField]
    Text text1,text2,text3,text4;
    string option  = "Menu";
 //   PlayerInfo _info;
    [SerializeField]
    GameObject slideBar;
    [SerializeField]
    Image mastervolumeImg,musicVolumeImg,effectsImg;
    [SerializeField]
    HelixScript _helixScript;
    AudioSource sceneMusic;
    AudioSource effects;
    string[] names;
    int i= 0;
    bool correctRes = false;

    protected virtual void Start()
    {
        base.Start();
        
        names = QualitySettings.names;
       
        
    }

    protected override void Update()
    {
 
        base.Update();
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            effects = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<AudioSource>();
        }
            if  (GameObject.FindGameObjectWithTag("SceneSound") != null)
        {
            sceneMusic = GameObject.FindGameObjectWithTag("SceneSound").GetComponent<AudioSource>();
        }
       // _info = GameObject.FindGameObjectWithTag("Info").GetComponent<PlayerInfo>();
    }
    protected override void case1()
    {
      switch (option)
        {
            case ("Resolution"):
                ResolutionMethod();
                break;
            case ("Menu"):
                slideBar.gameObject.SetActive(false);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    if (_helixScript != null)
                    {
                        _helixScript.menuHierachy += 1;
                    }
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
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    if (_helixScript != null)
                    {
                        _helixScript.menuHierachy += 1;
                    }
                    option = "Graphics";
                    text1.text = names[0];
                    text2.text = names [1];
                    text3.text = names [2];
                    text4.text = names[3];
                }
                break;
            case ("Graphics"):
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    if (_helixScript != null)
                    {
                        _helixScript.menuHierachy += 1;
                    }
                    QualitySettings.SetQualityLevel(0);
                }
                if (Input.GetKeyDown(KeyCode.Escape) && _helixScript.menuHierachy == 3)
                {
                    option = "Video";
                    text1.text = "Graphics";
                    text2.text = "Resolution";
                    text3.text = "Shadows";
                    text4.text = " ";
                }
                break;


            case ("Audio"):
                slideBar.gameObject.SetActive(true);
                mastervolumeImg.fillAmount = AudioListener.volume;
                musicVolumeImg.fillAmount = sceneMusic.volume;
                if (Input.GetKeyDown(KeyCode.A))
                {
               AudioListener.volume -= 0.1f;
                    if(AudioListener.volume <= 0)
                    {
                        AudioListener.volume = 0;
                    }
                    else if (AudioListener.volume >= 1)
                    {
                        AudioListener.volume = 1;
                    }

                }
               else  if (Input.GetKeyDown(KeyCode.D))
                {
                   AudioListener.volume += 0.1f;
                }

                break;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && _helixScript.menuHierachy == 2)
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
            case ("Resolution"):
                ResolutionMethod();
                break;
            case ("Video"):
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    if (_helixScript != null)
                    {
                        _helixScript.menuHierachy += 1;
                    }
                    option = "Resolution";
                    text1.text = "";
                    text2.text = "";
                    text3.text = "";
                    text4.text = "";

                }
                break;
            case ("Menu"):
                slideBar.gameObject.SetActive(false);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    if (_helixScript != null)
                    {
                        _helixScript.menuHierachy += 1;
                    }
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
            case ("Graphics"):
                if (Input.GetKeyDown(KeyCode.Escape) && _helixScript.menuHierachy == 3)
                {
                    option = "Video";
                    text1.text = "Graphics";
                    text2.text = "Resolution";
                    text3.text = "Shadows";
                    text4.text = " ";
                }
                if (Input.GetKeyDown(KeyCode.Escape) && _helixScript.menuHierachy == 3)
                {
                    option = "Video";
                    text1.text = "Graphics";
                    text2.text = "Resolution";
                    text3.text = "Shadows";
                    text4.text = " ";
                }
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    if (_helixScript != null)
                    {
                        _helixScript.menuHierachy += 1;
                    }
                    QualitySettings.SetQualityLevel(1);
                }
                break;
            case ("Audio"):
                slideBar.gameObject.SetActive(true);
                mastervolumeImg.fillAmount = AudioListener.volume;
                musicVolumeImg.fillAmount = sceneMusic.volume;
                if (Input.GetKeyDown(KeyCode.A))
                {
                    sceneMusic.volume -= 0.1f;
                    if (sceneMusic.volume <= 0)
                    {
                        sceneMusic.volume = 0;
                    }else if (sceneMusic.volume >= 1)
                    {
                        sceneMusic.volume = 1;
                    }


                }
                else if (Input.GetKeyDown(KeyCode.D))
                {
                    sceneMusic.volume += 0.1f;
                }
                break;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && _helixScript.menuHierachy <= 2)
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
        switch (option)
        {
            case ("Resolution"):
                ResolutionMethod();
                break;
            case ("Graphics"):
                if (Input.GetKeyDown(KeyCode.Escape) && _helixScript.menuHierachy == 3)
                {
                    option = "Video";
                    text1.text = "Graphics";
                    text2.text = "Resolution";
                    text3.text = "Shadows";
                    text4.text = " ";
                }
                if (Input.GetKeyDown(KeyCode.Escape) && _helixScript.menuHierachy == 3)
                {
                    option = "Video";
                    text1.text = "Graphics";
                    text2.text = "Resolution";
                    text3.text = "Shadows";
                    text4.text = " ";
                }

                if (Input.GetKeyDown(KeyCode.Return))
                {
                    if (_helixScript != null)
                    {
                        _helixScript.menuHierachy += 1;
                    }
                    QualitySettings.SetQualityLevel(2);
                }
                break;
            case ("Menu"):
                slideBar.gameObject.SetActive(false);
                break;
            case ("Audio"):
                slideBar.gameObject.SetActive(true);
                mastervolumeImg.fillAmount = AudioListener.volume;
                musicVolumeImg.fillAmount = sceneMusic.volume;
                effectsImg.fillAmount = effects.volume;
                if (Input.GetKeyDown(KeyCode.A))
                {
                   effects.volume -= 0.1f;
                    if (effects.volume <= 0)
                    {
                        effects.volume = 0;
                    }
                    else if (effects.volume >= 1)
                    {
                       effects.volume = 1;
                    }


                }
                else if (Input.GetKeyDown(KeyCode.D))
                {
                    effects.volume += 0.1f;
                }
                break;
        }
                if (Input.GetKeyDown(KeyCode.Escape) && _helixScript.menuHierachy <= 2)
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
        switch (option)
        {
            case ("Resolution"):
                ResolutionMethod();
                break;
            case ("Graphics"):
                if (Input.GetKeyDown(KeyCode.Escape) && _helixScript.menuHierachy == 3)
                {
                    option = "Video";
                    text1.text = "Graphics";
                    text2.text = "Resolution";
                    text3.text = "Shadows";
                    text4.text = " ";
                }
                if (Input.GetKeyDown(KeyCode.Escape) && _helixScript.menuHierachy == 3)
                {
                    option = "Video";
                    text1.text = "Graphics";
                    text2.text = "Resolution";
                    text3.text = "Shadows";
                    text4.text = " ";
                }

                if (Input.GetKeyDown(KeyCode.Return))
                {
                    if (_helixScript != null)
                    {
                        _helixScript.menuHierachy += 1;
                    }
                    QualitySettings.SetQualityLevel(3);
                }
                break;

            case ("Menu"):
                slideBar.gameObject.SetActive(false);
                break;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && _helixScript.menuHierachy <= 2)
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
        switch (option)
        {
            case ("Resolution"):
                ResolutionMethod();
                break;
            case ("Menu"):
                slideBar.gameObject.SetActive(false);
                break;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && _helixScript.menuHierachy <= 2)
        {
            
            option = "Menu";
            text1.text = "Video";
            text2.text = "Audio";
            text3.text = "Difficulty";
            text4.text = "KeyBinds";
        }
    }

    void ResolutionMethod ()
    {
     
        var res = Screen.resolutions.Where(resolution => resolution.refreshRate >= 60);
        Resolution[] resolutions = res.ToArray();
        print(resolutions.Length);
        if (correctRes == false)
        {
            for (i = 0; i < resolutions.Length; i++)
            {
                text1.text = resolutions[i].width.ToString() + "x" + resolutions[i].height.ToString();
                text2.text = i.ToString();
                if (text1.text == Screen.width.ToString() + "x" + Screen.height.ToString())
                {
                    correctRes = true;
                    break;

                }
            }
        }
        if(Input.GetKeyDown(KeyCode.D))
            {
            if (i< resolutions.Length) i++;
            Screen.SetResolution(resolutions[i].width,resolutions[i].height,true);
            text1.text = resolutions[i].width.ToString() + "x" + resolutions[i].height.ToString();
            text2.text = i.ToString();

        }
        else if (Input.GetKeyDown(KeyCode.A))
            {
            if (i > 0) i--;
            Screen.SetResolution(resolutions[i].width,resolutions[i].height, true);
            text1.text = resolutions[i].width.ToString() + "x" + resolutions[i].height.ToString();
            text2.text = i.ToString();

        }

    }
}
