using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HelixScript : MonoBehaviour {
    [SerializeField]
    Animator anim;
    [SerializeField]
    Image slot1, slot2, slot3;
    [SerializeField]
   Sprite Options, Fusions, Resume, Exit;
    [SerializeField]
    int selectionIs = 1;
    [SerializeField]
    OptionsWindowScript _options;
    int previusSelection;

	// Use this for initialization
	void Start () {
 
		
	}
	
	// Update is called once per frame
	void  Update () {
        if (Input.GetKeyDown(KeyCode.Escape) && _options.menuHierachy == 1)
        {
            anim.SetTrigger("Unselect");
        }

        if (selectionIs > 4)
        {
            selectionIs = 1;
        }
        if (selectionIs < 1)
        {
            selectionIs = 4;
        }
        switch (selectionIs)
        {
            case 1:
                if (Input.GetKeyDown(KeyCode.Return) && (_options.menuHierachy == 0))
                    
                {
                    _options.menuHierachy += 1;
                    anim.SetTrigger("fusions");
                    previusSelection = 1;
                }
                slot1.sprite = Resume;
                slot3.sprite = Fusions;
                slot2.sprite = Options;  
                break;

            case 2:
                if (Input.GetKeyDown(KeyCode.Return) && (_options.menuHierachy == 0))
                {
                    Time.timeScale = 1;
                    SceneManager.UnloadSceneAsync("menu");
                    previusSelection = 2;
                }
                    slot1.sprite = Exit;
                slot3.sprite = Resume;
                slot2.sprite = Fusions;
                break;
            case 3:
                if (Input.GetKeyDown(KeyCode.Return) && (_options.menuHierachy == 0))
                {
                    _options.menuHierachy += 1;
                    Time.timeScale = 1;
                    Destroy(GameObject.FindGameObjectWithTag("Info"));
                    SceneManager.LoadScene("Menu Inicial");
                 
                }
                slot1.sprite = Options;
                slot3.sprite = Exit;
                slot2.sprite = Resume;
                break;

            case 4:
                if (Input.GetKeyDown(KeyCode.Return) && (_options.menuHierachy == 0))
                {
                    _options.menuHierachy += 1;
                    anim.SetTrigger("options");
                    previusSelection = 4;
                }

                slot1.sprite = Fusions;
                slot3.sprite = Options;
                slot2.sprite = Exit;
                break;
        }

                if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            selectionIs += 1;
            if (_options.menuHierachy == 0)
            {
                anim.SetTrigger("HelixMoveright");
            }

        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            selectionIs -= 1;
            if (_options.menuHierachy == 0)
            {
                anim.SetTrigger("HelixMoveLeft");
            }
 
        }
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (_options.menuHierachy == 0)
            {
                Time.timeScale = 1;
                SceneManager.UnloadSceneAsync("menu");
               
            }
            if (_options.menuHierachy >= 1)
            {
                selectionIs = previusSelection;
            }
            if (_options.menuHierachy != 0)
            {
                _options.menuHierachy -= 1;
            }
          
        }
    
    }
}
