using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputEnterMenuInicial : MonoBehaviour
{
    [SerializeField]
    GameObject Options, This, LoadSelection, Play;
    [SerializeField]
    MenuInicialSelection _selectionscript;
    Animator animUI;
    // Use this for initialization
    void Start()
    {
       // _selectionscript = GetComponent<MenuInicialSelection>();
        animUI = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Escape))
        {
            This.active = true;
            Options.active = false;
            LoadSelection.active = false;
            Play.active = false;

            _selectionscript.selectionIs = 0;
        }

        if (_selectionscript.selectionIs == 2 && Input.GetKey(KeyCode.Return))
        {
            Options.active = true;
            This.active = false;
        }
        if (_selectionscript.selectionIs == 1 && Input.GetKey(KeyCode.Return))
        {

            LoadSelection.active = true;
            This.active = false;
        }
        if (_selectionscript.selectionIs == 0 && Input.GetKey(KeyCode.Return))
        {

            Play.active = true;
            This.active = false;
        }
        if (_selectionscript.selectionIs == 3 && Input.GetKey(KeyCode.Return))
        {
            SceneManager.LoadScene("Credits", LoadSceneMode.Single);
        }
      
    }
}