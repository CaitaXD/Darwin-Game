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
    int selectionIs = 1;

	// Use this for initialization
	void Start () {
 
		
	}
	
	// Update is called once per frame
	void  Update () {
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
                slot1.sprite = Resume;
                slot3.sprite = Fusions;
                slot2.sprite = Options;  
                break;

            case 2:
                slot1.sprite = Exit;
                slot3.sprite = Resume;
                slot2.sprite = Fusions;
                break;
            case 3:
                slot1.sprite = Options;
                slot3.sprite = Exit;
                slot2.sprite = Resume;
                break;

            case 4:
                slot1.sprite = Fusions;
                slot3.sprite = Options;
                slot2.sprite = Exit;
                break;
        }

                if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            selectionIs += 1;
            anim.SetTrigger("HelixMoveright");

        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            selectionIs -= 1;
             anim.SetTrigger("HelixMoveLeft");
 
        }
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Time.timeScale = 1;
            SceneManager.UnloadSceneAsync("menu");
        }
    
    }
}
