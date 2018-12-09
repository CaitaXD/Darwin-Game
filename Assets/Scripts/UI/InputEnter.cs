using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Input enter do menu pausa
public class InputEnter : MonoBehaviour
{
    [SerializeField]
    MenuPauseSelectionScript Slot1, Slot2;
   MenuPauseSelectionScript _selectionscript;
    Animator animUI;
    // Use this for initialization
    void Start()
    {
        _selectionscript = GetComponent<MenuPauseSelectionScript>();
        animUI = GetComponentInParent<Animator>();
      
    }

    // Update is called once per frame
    void Update()
    {
        if (_selectionscript.selectionIs == 3 && Input.GetKey(KeyCode.Return))
        {
            _selectionscript.selectionIs = 99;
            Slot1.selectionIs =99;
            Slot2.selectionIs =99;
            animUI.SetBool("isSelected", true);
           

        }
        if (_selectionscript.selectionIs == 0 && Input.GetKey(KeyCode.Return))
        {
            _selectionscript.selectionIs = 99;
            Slot1.selectionIs = 99;
            Slot2.selectionIs = 99;
            animUI.SetBool("TransformSelected", true);
           
        }
        if (animUI.GetBool("isSelected") == true || animUI.GetBool("TransformSelected") == true)
        {
            _selectionscript.selectionIs = 99;
            Slot1.selectionIs = 99;
            Slot2.selectionIs = 99;
        }
        if (Input.GetKey(KeyCode.Escape) && animUI.GetBool("isSelected") == true)
        {
            
            animUI.SetBool("isSelected", false);
            animUI.SetTrigger("Unselect");
        

        }
        if (Input.GetKey(KeyCode.Escape) && animUI.GetBool("TransformSelected") == true)
        {
            _selectionscript = GetComponent<MenuPauseSelectionScript>();
            animUI.SetBool("TransformSelected", false);
            

        }
        if (_selectionscript.selectionIs == 1 && Input.GetKey(KeyCode.Return))
        {
            SceneManager.UnloadScene("Menu");
            Time.timeScale = 1;
        }
        if (_selectionscript.selectionIs == 2 && Input.GetKey(KeyCode.Return))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("Menu Inicial", LoadSceneMode.Single);
        }
    }
}