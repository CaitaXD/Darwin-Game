using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuPauseSelectionScript: MonoBehaviour {
   public  int selectionIs = 0;
    Sprite _sprite= null;
    [SerializeField]
    Sprite image1= null ,image2 = null,image3= null,image4 = null;
    public float timer = 0;
    public bool onOff= true;
  
    
	// Use this for initialization
	void Start () {
        _sprite = image1;
        Time.timeScale = 0;


    }
	
	// Update is called once per frame
	void Update () {
        if (timer >= 1)
        timer +=  Time.unscaledDeltaTime;
     
        GetComponent<Image>().sprite = _sprite;

        //Muda as sprites das outras opções para ficar certinho no menu pausa
        switch (selectionIs)
        {
            case 0:
                if (timer > 1.2)
                {
                   
                    _sprite = image1;
                    timer = 0;
                }
                break;
            case 1:
                if (timer > 1.2)
                {
                    
                    _sprite = image2;
                    timer = 0;
                }
                break;
            case 2:
                if (timer > 1.2)
                {

                    _sprite = image3;
                    timer = 0;
                }
                break;
            case 3:
                if (timer > 1.2)
                {
                  
                    _sprite = image4;
                    timer = 0;
                }
                break;
            default:
               
                 
                    _sprite = image1;
                
                break;

        }


        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            selectionIs += 1;
            timer = 1;
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            selectionIs -= 1;
            timer = 1;
        }
        if (selectionIs >= 4) selectionIs = 0;
        if (selectionIs < 0) selectionIs = 3;


        gameObject.active = onOff;
    }

}
