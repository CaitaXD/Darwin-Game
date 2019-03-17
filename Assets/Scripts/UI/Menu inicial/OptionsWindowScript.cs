using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class OptionsWindowScript : SelectionMasterScript {
    [SerializeField]
    Text text1,text2,text3,text4;
    string option  = "Menu";
    [SerializeField]
    GameObject slideBar;
    [SerializeField]
    Image mastervolumeImg,musicVolumeImg,effectsImg;
  //  [SerializeField]
  //  HelixScript _helixScript;
    string[] names;
    public int menuHierachy;
    int i = 0;
    bool correctRes = false;
    public  float sceneMusic = 0.5f, batlleSounds= 0.5f, ambientMusic = 0.5f;
    AudioReader _audioReader;
    public float enemySpeedMod, enemyDamageMod, enemyRangeMod;
    int DifficultyLevel = 2;

    protected  override void Start()
    {  

        if (GameObject.FindGameObjectWithTag("AudioReader") == null) { }
        else
        {
            _audioReader = GameObject.FindGameObjectWithTag("AudioReader").GetComponent<AudioReader>();
           sceneMusic = _audioReader.sceneMusic; batlleSounds=_audioReader.batlleSounds ; ambientMusic = _audioReader.ambientMusic;
            DifficultyLevel = _audioReader.DifficultyLevel;
        }
        base.Start();
        names = QualitySettings.names;
    }

    protected override void Update()
    {

        base.Update();
        if (Input.GetKeyDown(KeyCode.Escape) && menuHierachy == 1)
        {
            SaveSystem.SaveAudioData(_audioReader);
            }
      
        }
    protected override void case1()
    {
      switch (option)
        {
            case ("Difficulty"):
                if (DifficultyLevel == 1)
                {
                    text1.color = Color.gray;
                    text2.color = Color.white;
                    text3.color = Color.white;
                    text4.color = Color.white;
                    if (Input.GetKeyDown(KeyCode.Escape))
                    {
                        text1.color = Color.white;
                        text2.color = Color.white;
                        text3.color = Color.white;
                        text4.color = Color.white;
                    }
                }
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    DifficultyLevel = 1;
                    _audioReader.DifficultyLevel = DifficultyLevel;
                  
                }    
                break;
            case ("Shadows"):
                if (Input.GetKeyDown(KeyCode.Return))
                {
                   
                }
                if (Input.GetKeyDown(KeyCode.Escape) && menuHierachy == 3)
                {
                    option = "Video";
                    text1.text = "Graphics";
                    text2.text = "Resolution";
                    text3.text = "Shadows";
                    text4.text = " ";
                }
                break;

            case ("Resolution"):
                ResolutionMethod();
                break;
            case ("Menu"):
                slideBar.gameObject.SetActive(false);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                       menuHierachy += 1;
                    
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
                   menuHierachy += 1;
                    
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
                   menuHierachy += 1;
                    
                    QualitySettings.SetQualityLevel(0);
                }
                if (Input.GetKeyDown(KeyCode.Escape) && menuHierachy == 3)
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
                musicVolumeImg.fillAmount = sceneMusic;
                effectsImg.fillAmount = batlleSounds;
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
        if (Input.GetKeyDown(KeyCode.Escape) && menuHierachy == 2)
        {
            SaveSystem.SaveAudioData(_audioReader);
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
            case ("Difficulty"):
                if (DifficultyLevel == 2)
                {
                    text1.color = Color.white;
                    text2.color = Color.gray;
                    text3.color = Color.white;
                    text4.color = Color.white;
                    if (Input.GetKeyDown(KeyCode.Escape))
                    {
                        text1.color = Color.white;
                        text2.color = Color.white;
                        text3.color = Color.white;
                        text4.color = Color.white;
                    }
                }
               
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    DifficultyLevel = 2;
                    _audioReader.DifficultyLevel = DifficultyLevel;

                }
                break;
            case ("Shadows"):
                if (Input.GetKeyDown(KeyCode.Return))
                {
                   
                }
                if (Input.GetKeyDown(KeyCode.Escape) && menuHierachy == 3)
                {
                    option = "Video";
                    text1.text = "Graphics";
                    text2.text = "Resolution";
                    text3.text = "Shadows";
                    text4.text = " ";
                }
                break;
            case ("Resolution"):
                ResolutionMethod();
                break;
            case ("Video"):
                if (Input.GetKeyDown(KeyCode.Return))
                {
                 menuHierachy += 1;
                    
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
                   menuHierachy += 1;
                    
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
             
                if (Input.GetKeyDown(KeyCode.Escape) && menuHierachy == 3)
                {
                    option = "Video";
                    text1.text = "Graphics";
                    text2.text = "Resolution";
                    text3.text = "Shadows";
                    text4.text = " ";
                }
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    menuHierachy += 1;
                    
                    QualitySettings.SetQualityLevel(1);
                }
                break;
            case ("Audio"):
                slideBar.gameObject.SetActive(true);
                mastervolumeImg.fillAmount = AudioListener.volume;
                musicVolumeImg.fillAmount = sceneMusic;
                effectsImg.fillAmount = batlleSounds;
                if (Input.GetKeyDown(KeyCode.A))
                {
                    sceneMusic -= 0.1f;
                    _audioReader.sceneMusic = sceneMusic;
                    if (sceneMusic <= 0)
                    {
                        sceneMusic = 0;
                    }else if (sceneMusic >= 1)
                    {
                        sceneMusic = 1;
                    }


                }
                else if (Input.GetKeyDown(KeyCode.D))
                {
                    sceneMusic += 0.1f;
                    _audioReader.sceneMusic = sceneMusic;
                }
                break;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && menuHierachy <= 2)
        {

            SaveSystem.SaveAudioData(_audioReader);
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
            case ("Difficulty"):
                if (DifficultyLevel == 3){
                    text1.color = Color.white;
                    text2.color = Color.white;
                    text3.color = Color.gray;
                    text4.color = Color.white;
                    if (Input.GetKeyDown(KeyCode.Escape))
                    {
                        text1.color = Color.white;
                        text2.color = Color.white;
                        text3.color = Color.white;
                        text4.color = Color.white;
                    }
                }
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    DifficultyLevel = 3;
                    _audioReader.DifficultyLevel = DifficultyLevel;

                }
                break;
            case ("Shadows"):
                if (Input.GetKeyDown(KeyCode.Return))
                {
                  
                }
                if (Input.GetKeyDown(KeyCode.Escape) && menuHierachy == 3)
                {
                    option = "Video";
                    text1.text = "Graphics";
                    text2.text = "Resolution";
                    text3.text = "Shadows";
                    text4.text = " ";
                }
                break;
            case ("Video"):
                if (Input.GetKeyDown(KeyCode.Return) &&menuHierachy == 2)
                {
                    menuHierachy += 1;
                    option = "Shadows";
                    text1.text = "";
                    text2.text = "";
                    text3.text = "";
                    text4.text = "";
                }


                break;
            case ("Resolution"):
                ResolutionMethod();
                break;
            case ("Graphics"):
                if (Input.GetKeyDown(KeyCode.Escape) &&menuHierachy == 3)
                {
                    option = "Video";
                    text1.text = "Graphics";
                    text2.text = "Resolution";
                    text3.text = "Shadows";
                    text4.text = " ";
                }
                if (Input.GetKeyDown(KeyCode.Escape) && menuHierachy == 3)
                {
                    option = "Video";
                    text1.text = "Graphics";
                    text2.text = "Resolution";
                    text3.text = "Shadows";
                    text4.text = " ";
                }

                if (Input.GetKeyDown(KeyCode.Return))
                {
                menuHierachy += 1;
                    
                    QualitySettings.SetQualityLevel(2);
                }
                break;
            case ("Menu"):
                slideBar.gameObject.SetActive(false);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    switch (DifficultyLevel)
                    {
                        case (1):
                            _audioReader.Easy();
                            text1.color = Color.gray;
                            text2.color = Color.white;
                            text3.color = Color.white;
                            text4.color = Color.white;
                            break;
                        case (2):
                            _audioReader.Normal();
                            text1.color = Color.white;
                            text2.color = Color.gray;
                            text3.color = Color.white;
                            text4.color = Color.white;
                            break;
                        case (3):
                            _audioReader.Hard();
                            text1.color = Color.white;
                            text2.color = Color.white;
                            text3.color = Color.gray;
                            text4.color = Color.white;
                            break;
                        case (4):
                            _audioReader.Insane();
                            text1.color = Color.white;
                            text2.color = Color.white;
                            text3.color = Color.white; 
                            text4.color = Color.gray;
                            break;
                    }

                    menuHierachy += 1;

                    option = "Difficulty";
                    text1.text = "Easy";
                    text2.text = "Normal";
                    text3.text = "Hard";
                    text4.text = "Insane";
                }

                break;
            case ("Audio"):
                slideBar.gameObject.SetActive(true);
                mastervolumeImg.fillAmount = AudioListener.volume;
                musicVolumeImg.fillAmount = sceneMusic;
                effectsImg.fillAmount = batlleSounds;
                if (Input.GetKeyDown(KeyCode.A))
                {
                  batlleSounds -= 0.1f;
                    _audioReader.batlleSounds = batlleSounds;
                }
                else if (Input.GetKeyDown(KeyCode.D))
                {
                    batlleSounds += 0.1f;
                    _audioReader.batlleSounds = batlleSounds;
                }
                if (batlleSounds <= 0)
                {
                    batlleSounds = 0;
                }
                else if (batlleSounds >= 1)
                {
                    batlleSounds = 1;
                }

                break;
        }
                if (Input.GetKeyDown(KeyCode.Escape) && menuHierachy <= 2)
        {
            SaveSystem.SaveAudioData(_audioReader);
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
            case ("Difficulty"):
                if (DifficultyLevel == 4)
                {
                    text1.color = Color.white;
                    text2.color = Color.white;
                    text3.color = Color.white;
                    text4.color = Color.gray;
                    if (Input.GetKeyDown(KeyCode.Escape))
                    {
                        text1.color = Color.white;
                        text2.color = Color.white;
                        text3.color = Color.white;
                        text4.color = Color.white;
                    }
                }
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    DifficultyLevel = 4;
                    _audioReader.DifficultyLevel = DifficultyLevel;

                }
                break;
            case ("Shadows"):
                if (Input.GetKeyDown(KeyCode.Return))
                {
                
                }
                if (Input.GetKeyDown(KeyCode.Escape) && menuHierachy == 3)
                {
                    option = "Video";
                    text1.text = "Graphics";
                    text2.text = "Resolution";
                    text3.text = "Shadows";
                    text4.text = " ";
                }
                break;
            case ("Resolution"):
                ResolutionMethod();
                break;
            case ("Graphics"):
                if (Input.GetKeyDown(KeyCode.Escape) && menuHierachy == 3)
                {
                    option = "Video";
                    text1.text = "Graphics";
                    text2.text = "Resolution";
                    text3.text = "Shadows";
                    text4.text = " ";
                }
                if (Input.GetKeyDown(KeyCode.Escape) &&menuHierachy == 3)
                {
                    option = "Video";
                    text1.text = "Graphics";
                    text2.text = "Resolution";
                    text3.text = "Shadows";
                    text4.text = " ";
                }

                if (Input.GetKeyDown(KeyCode.Return))
                {
                  menuHierachy += 1;
                    
                    QualitySettings.SetQualityLevel(3);
                }
                break;

            case ("Menu"):
                slideBar.gameObject.SetActive(false);
                break;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && menuHierachy <= 2)
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
            case ("Shadows"):
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    
                }
                if (Input.GetKeyDown(KeyCode.Escape) && menuHierachy == 3)
                {
                    option = "Video";
                    text1.text = "Graphics";
                    text2.text = "Resolution";
                    text3.text = "Shadows";
                    text4.text = " ";
                }
                break;
            case ("Resolution"):
                ResolutionMethod();
                break;
            case ("Menu"):
                slideBar.gameObject.SetActive(false);
                break;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && menuHierachy <= 2)
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
        if (Input.GetKeyDown(KeyCode.Escape) && menuHierachy == 3)
        {
            option = "Video";
            text1.text = "Graphics";
            text2.text = "Resolution";
            text3.text = "Shadows";
            text4.text = " ";
        }
    }
  
}
