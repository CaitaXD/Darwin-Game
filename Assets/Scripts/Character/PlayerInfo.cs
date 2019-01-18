using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    public float life;
    PlayerScript _playerScript;
    [SerializeField]
    public int checkID;
    [SerializeField]
    protected int cheknewID;
    public GameObject currentFusion;
    public float timerSpawn;
    public bool activatTimer;
    fusionScript _fusionScript;
    public List<int> id;
    public float number;
    public bool tutorialRestrictions = false;
    [SerializeField]
    Vector3 Spawn;
    public float healAmount;
    [SerializeField]
    AudioSource HealSound;

    private void Awake()
    {
        //Linha que faz o objeto continuar em todas as fases para salvar a fusão/ vida/ spawn
        DontDestroyOnLoad(this.gameObject);     
        cheknewID = checkID;
        life = 100;
        
    }
  
    public virtual void FixedUpdate()
    {


        //Procura o spawn
        if (GameObject.FindGameObjectWithTag("Spawn") != null)
            {
            Spawn = GameObject.FindGameObjectWithTag("Spawn").GetComponent<Transform>().position;
        }
        //Método que faz o ''New Fusion'' aparecer na tela e adiciona a fusão no menu fusions
        if (cheknewID != checkID)
        {
            HealSound.Play();
            cheknewID = checkID;
            if (!id.Contains(checkID))
            {
                if (GameObject.FindGameObjectWithTag("NewFusion") != null)
                {
                    GameObject.FindGameObjectWithTag("NewFusion").GetComponent<Animator>().SetTrigger("appear");
                }
                id.Add(checkID);
            }           
        }
                    
        if (activatTimer)
        {
            timerSpawn += Time.deltaTime; //Verifica se a fusão é uma fusão feita na fase ou uma fusão iniciada na fase
        }
        if (timerSpawn >= 1.3)
        {
            timerSpawn = 0;
            activatTimer = false;
        }


        //Se o ID não for igual, o prefab da fusão é guardado
        if (GameObject.FindGameObjectWithTag("Player")!= null && GameObject.FindGameObjectWithTag("Player").GetComponent<fusionScript>().fusionID != checkID)
        {
            
            if (timerSpawn >= 1.2)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<fusionScript>().fusionStore = true;
                    
                timerSpawn = 0;
                activatTimer = false;
            }
        }
        //Spawna o Player
        else if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            Instantiate(currentFusion, Spawn, new Quaternion(0, 0, 0, 0));
        }

    }
   
    
}
