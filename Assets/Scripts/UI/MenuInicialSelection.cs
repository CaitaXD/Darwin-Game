using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuInicialSelection : MonoBehaviour
{   [SerializeField]
    Animator anim;
    [SerializeField]
    AudioSource ahead;
    public int selectionIs= 0;
    
    public bool onOff = true;

  
    void Update()
    {
      
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow)) selectionIs -= 1;
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow)) selectionIs += 1;
        if (selectionIs >= 4) selectionIs = 0;
        if (selectionIs < 0) selectionIs = 3;
        if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            anim.SetTrigger("Darrow");
          ahead.Play();
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))

        {
            anim.SetTrigger("Uparrow");
          
            ahead.Play();
        }


        gameObject.active = onOff;
     

    }

}
