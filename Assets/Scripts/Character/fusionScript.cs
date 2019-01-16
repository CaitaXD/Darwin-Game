using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fusionScript : MonoBehaviour
{
    PlayerScript _playerScript;
    FusionStore _fusionStore;
    public GameObject OriginalDarwin;
    public Transform darwinPos;
    public Animator animPlayer;
    public GameObject FusionGet;
    [SerializeField]
    bool isTriggred; //Server para desativar o hint de press tab to fuse
    float timerFusion;
    bool activateTimer;
    float fusionspamlock = 0;
    public bool fusionStore = false;
    public int fusionID = 99;
    public GameObject currentFusion;
    public GameObject Spawn;
    PlayerInfo Info;

    // Use this for initialization
    private void Awake()
    {
        Info = GameObject.FindGameObjectWithTag("Info").GetComponent<PlayerInfo>();
        Info.activatTimer = true;
        animPlayer = GetComponentInChildren<Animator>();
        FusionGet = GetComponent<GameObject>();
        _playerScript = GetComponent<PlayerScript>();
       
        isTriggred = false;
    }

    private void Start()
    {
        if (_playerScript.hitPoints <= 100)
        {
            _playerScript.hitPoints += Info.healAmount;
        }
    }
    // Update is called once per frame
    void Update()
    {
        Spawn = GameObject.FindGameObjectWithTag("Spawn");
        //Confere e atualiza o ID da fusão presente em um gameobject dontdestroyonload
        if (fusionID != Info.checkID)
        {
           Info.checkID = fusionID;
        }
        //Instancia o player quando o player troca de fase
        if (fusionStore == true)
        {
            Transform transform1 = Spawn.transform;
            if (Spawn != null)
            {
                Instantiate(GameObject.FindGameObjectWithTag("Info").GetComponent<PlayerInfo>().currentFusion, new Vector3(transform1.position.x, transform1.position.y, transform1.position.z), new Quaternion(0, 0, 0, 0));
                GameObject.Destroy(gameObject);
                fusionStore = false;
            }
        }
        if (activateTimer == true)
        {
            timerFusion += Time.deltaTime;
        }

        if (timerFusion >= 1.1)
        {
            Fusion(FusionGet);
        }

           /* if (OriginalDarwin != null)
            {
                Originaldarwin();
            }*/
    }

  
    private void OnTriggerExit(Collider collider)
    {
        isTriggred = false;
    }
    private void OnTriggerStay(Collider collider)
    {
        //Para prevenir null reference
        if (collider.gameObject.tag == ("Untagged") || collider.gameObject.tag == ("Camera Angle 1") || collider.gameObject.tag == ("Camera Angle 2") || collider.gameObject.tag == ("Camera Angle 3"))
        {
            
        }
        else
        {
            isTriggred = true;
        }
        //Se o input de fusao for ativado enquanto o inimigo está morto, começa a animação de fusão e guarda a fusão do prefab inimigo
        if (collider.gameObject.tag == ("Dead"))
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                animPlayer.SetTrigger("fusion");
                _fusionStore = collider.GetComponent<FusionStore>();
               
                Info.healAmount = _fusionStore.healAmount;
                FusionGet = _fusionStore.FusionPrefab;
                GameObject.Destroy(collider.gameObject);
                if (collider.GetComponent<EnemyScript>() != null)
                {
                    Destroy(collider.GetComponent<EnemyScript>().stunObj);
                }
                else
                {

                }
                activateTimer = true;
            }   
        }
    }
  
   /*void Originaldarwin()
    {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
            GameObject.FindGameObjectWithTag("Info").GetComponent<PlayerInfo>().checkID = 0;
            Instantiate(OriginalDarwin.gameObject, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), new Quaternion(0, 0, 0, 0));
               GameObject.Destroy(gameObject);
            }
    }
*/
//Método que realiza a fusão
   public void Fusion(GameObject Prefab)
    {
        Instantiate(Prefab, new Vector3(transform.gameObject.transform.position.x, transform.gameObject.transform.position.y, transform.position.z), new Quaternion(0, 0, 0, 0));
        GameObject.Destroy(gameObject);
        GameObject.FindGameObjectWithTag("Info").GetComponent<PlayerInfo>().currentFusion = Prefab;
        GameObject.FindGameObjectWithTag("Info").GetComponent<PlayerInfo>().activatTimer = true;
        GameObject.FindGameObjectWithTag("Info").GetComponent<PlayerInfo>().checkID = fusionID;
        isTriggred = false;
    }
}
