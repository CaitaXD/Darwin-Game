using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOverSelectionScript : MonoBehaviour {
    [SerializeField]
    int SelectionIs;
    [SerializeField]
    Text stayBad,gidGud;
    string stage;
  
    //Funcionamento da tela de game over
    void Update () {
        Time.timeScale = 0;
        stage = SceneManager.GetSceneAt(0).name;
        if (Input.GetKeyDown(KeyCode.A)|| Input.GetKeyDown(KeyCode.A)) SelectionIs += 1;
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.S)) SelectionIs -= 1;
        switch (SelectionIs)
        {
            case 0:
                stayBad.color = Color.grey;
                gidGud.color = Color.white;
                if (Input.GetKey(KeyCode.Return))
                {
                    Time.timeScale = 1;
                    //Destroi o info pois o menu não necessita
                    Destroy(GameObject.FindGameObjectWithTag("Info"));
                    SceneManager.LoadScene("Menu Inicial", LoadSceneMode.Single);
                }
                break;
            case 1:
                if (stage == "DesertPartOne")
                {
                    //Destroi o info pois o deserto já possui um
                    Destroy(GameObject.FindGameObjectWithTag("Info"));
                }
                
                stayBad.color = Color.white;
                gidGud.color = Color.gray;
                if (Input.GetKey(KeyCode.Return))
                {
                    Time.timeScale = 1;
                    SceneManager.LoadScene(stage, LoadSceneMode.Single);
                    GameObject.FindGameObjectWithTag("Info").GetComponent<PlayerInfo>().life = 100;
                }
                break;
              
            case 2:
                SelectionIs = 0;
                break;
            case -1:
                SelectionIs = 1;
                
                break;
               
        }
       

      


    }
}
