using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Inputs do menu inicial
public class PlaySeletcionscript : MonoBehaviour {
    [SerializeField]
    MenuInicialSelection _selectionscript;
    [SerializeField]
     float timer;
    [SerializeField]
    AudioSource plin;
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {         
            timer = 0;
            _selectionscript.selectionIs = 0;
        }
    }
    void FixedUpdate () {
       
        timer += Time.deltaTime;
        if (timer > 1)
            {
            if (_selectionscript.selectionIs == 0 && Input.GetKey(KeyCode.Return))
            {
                plin.Play();
                SceneManager.LoadScene("TutorialJumpandFusion", LoadSceneMode.Single);
            }
            if (_selectionscript.selectionIs == 1 && Input.GetKey(KeyCode.Return))
            {
                plin.Play();
                if (GameObject.FindGameObjectWithTag("Info") != null) Destroy(GameObject.FindGameObjectWithTag("Info"));
                SceneManager.LoadScene("TutorialJumpandFusion", LoadSceneMode.Single);
            }
        }
    }
}
