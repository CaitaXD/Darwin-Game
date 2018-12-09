using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FusionSlot : MonoBehaviour
{
    [SerializeField]
    Text Description;
    [SerializeField]
    PlayerInfo _playerInfo;
    public int slotnum;
    [SerializeField]
    Image Dysplay;
    [SerializeField]
    Sprite darpionSprite, lockedSprite, DarwinSprite,BatDarwinSprite;
    [SerializeField]
    int selectionIs;
    Text DysplayText;
    [SerializeField]
    GameObject Darwin, Darpion,BatDarwin;
    int InternalIndex;
    [SerializeField]
    Image a, b;
    [SerializeField]
    Sprite a99, b99, a1, b1, a2, b2, none;

    private void Start()
    {
        DysplayText = GetComponent<Text>();
        _playerInfo = GameObject.FindGameObjectWithTag("Info").GetComponent<PlayerInfo>();
    }
    private void Update()
    {
       
        if (selectionIs == slotnum)
        {  //Muda a cor da seleção
            DysplayText.color = Color.red;
            switch (slotnum)
            {
                case 0:
                    DysplayFigure();  

                    break;
                case 1:
                    DysplayFigure();
                  
                    break;
                case 2:
                    DysplayFigure();
                    break;

            }
        }
        else   //Muda a cor da seleção
            DysplayText.color = Color.white;

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow)) selectionIs -= 1;
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow)) selectionIs += 1;
        if (selectionIs > 4) selectionIs = 0;
        if (selectionIs < 0) selectionIs = 4;
        InternalIndex = _playerInfo.id[slotnum];

        switch (InternalIndex)
        {
            case 99:
                GetComponent<Text>().text = "Darwin";
               

                break;
            case 1:
                GetComponent<Text>().text = "Darpion";
               

                break;
            case 2:
                GetComponent<Text>().text = "BatDarwin";
               
                break;
         
        }





    }
    //Sprites do menu fusions/ Descrições
    void DysplayFigure()
    {
        switch (GetComponent<Text>().text)
        {
            case "Darwin":
                a.sprite = a99; b.sprite = b99;
                Dysplay.sprite = DarwinSprite;
                if (Input.GetKey(KeyCode.Return))
                { GameObject.FindGameObjectWithTag("Player").GetComponent<fusionScript>().Fusion(Darwin);
                    Time.timeScale = 1;
                    SceneManager.UnloadSceneAsync("menu");
                }
                Description.text = "Darwin's Base Form";

                break;

            case "Darpion":
                a.sprite = a1; b.sprite = none;
                Dysplay.sprite = darpionSprite;
                if (Input.GetKey(KeyCode.Return))
                { GameObject.FindGameObjectWithTag("Player").GetComponent<fusionScript>().Fusion(Darpion);
                    Time.timeScale = 1;
                    SceneManager.UnloadSceneAsync("menu");
                }
                Description.text = "Darwin Fused with a Scorpion";
                break;
            case "BatDarwin":
                a.sprite = a2; b.sprite = none;
                Dysplay.sprite = BatDarwinSprite;
                if (Input.GetKey(KeyCode.Return))
                {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<fusionScript>().Fusion(BatDarwin);
                    Time.timeScale = 1;
                    SceneManager.UnloadSceneAsync("menu");
                }
                Description.text = "Darwin Fused with a Bat";
                break;
               
            case "Unkown":
                a.sprite = lockedSprite; b.sprite =lockedSprite;
                Dysplay.sprite = lockedSprite;
                Description.text = "Locked";
                break;


        }
    }

  
       

}

