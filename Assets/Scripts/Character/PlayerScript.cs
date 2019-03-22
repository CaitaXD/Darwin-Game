using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : Character {
  public static KeyCode Action1 = KeyCode.R, Action2 = KeyCode.T, Action3, Jump = KeyCode.Space, Interact = KeyCode.Tab;
    [SerializeField]
    protected float rollVelocity, stompVelocity;
    public float horizontal;
    protected float timerRoll, timerJump;
    public bool JumpDelay, RollDelay;
   public EnemyScript _enemyScript;
    [SerializeField]
    public SphereCollider damagecollider;
    public CameraScript _cameraScript;
    public bool Cinematic;
    public float CinematicDuration;
    protected  DamageScript _damageScript;
    bool loaded;
    public float idleTimer;
    public bool QuickSand = false;
    int timedBlockStatus;
    public bool deactivateParallax = false;
    float collectibles;
    public bool collectOnce = false;
    [SerializeField]
    protected Vector3 ResetEuler;
    PlayerInfo _playerInfo;
    //Para matar o Player no final da animação
    bool deadtimer;
    float timerdead;


 public override  void Start()
    {
        _playerInfo = GameObject.FindGameObjectWithTag("Info").GetComponent<PlayerInfo>();
        base.Start();
        gameObject.transform.eulerAngles = ResetEuler;
        _damageScript = GetComponentInChildren<DamageScript>();
        hitPoints = _playerInfo.life;
        rBody = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        _cameraScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraScript>();
        //Verifica se o loading terminou
        if (loaded == true)
        {
            anim.SetBool("loaded", true);
            Cinematic = true;
            rBody.velocity = new Vector3(10, 5, 0);
        }
    }
    public override void FixedUpdate()
    {  
        if(deadtimer)
        {
            timerdead += Time.deltaTime;
        }
        //Se o Player Possuir a tag Dead, carrega o game over
        if (tag == "Dead")
        {
            if (SceneManager.sceneCount < 2)
            {
                SceneManager.LoadScene("GameOber", LoadSceneMode.Additive);
            }
        }
        base.FixedUpdate();
        //Atualiza para um gameobject com dontdestroyonload quanto de vida o player tem
        if (this.hitPoints != 0)
        {
            if (this.hitPoints != GameObject.FindGameObjectWithTag("Info").GetComponent<PlayerInfo>().life)
            {
                GameObject.FindGameObjectWithTag("Info").GetComponent<PlayerInfo>().life = this.hitPoints;
            }
        }
        //Ativa o método de bloqueio com precisão
        if (timedBlockStatus == 1)
        {
            Timedblock();
            isBlocking = true;
        }
        else { }
       
        timerRoll += Time.deltaTime;
        idleTimer += Time.deltaTime;
        //Após um Certo tempo parado uma idlesleep é iniciada
        if (idleTimer >= 5)
        {
            anim.SetBool("Sleep", true);

        }
        //Cancela o IdleSleep 
        if (idleTimer < 4.9) anim.SetBool("Sleep", false);

        if (Cinematic == true)
        {
            CinematicDuration += Time.deltaTime;
        }

        if (CinematicDuration >= 4)
        {
            Cinematic = false;
            CinematicDuration = 0;
        }
        //Impede que o player abuse dos inputs 
        if (JumpDelay)
        {
            timerJump += Time.deltaTime;
            if (timerJump >= 0.2f)
            {
                JumpDelay = false;
                timerJump = 0;
            }


        }
        //Impede que o player abuse dos inputs 
        if (RollDelay)
        {
            MethodRollDealy();
        }


        //Gravidade
        rBody.AddForce(new Vector3(0, -gravity, 0));
        //Confere onde está o chão
        Collider[] collider = Physics.OverlapSphere(groundPoint.position, 0.2f, whatisGround);
        onGround = collider.Length > 0;
        
        HandleInput();
        AttackInput();
        ImmunityeMethod();
       
       
    }

    //Inputs do PLayer
    public void HandleInput()
    {
        if (Cinematic == false)
        {
            if (SceneManager.sceneCount == 1 && Input.GetKeyUp(KeyCode.Escape) && _playerInfo.tutorialRestrictions == false)
            {
                SceneManager.LoadScene("Menu", LoadSceneMode.Additive);
                Time.timeScale = 0;
            }
            //Confere se o player está na areia movediça
            if (QuickSand == false)
            {
                // Movment Input
                horizontal = Input.GetAxisRaw("Horizontal") * walkVelocity * Time.deltaTime;
                //Muda a direção do personagem/Ativa animação de caminhar
                if (horizontal < 0)
                {
                    gameObject.transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, -90, transform.localEulerAngles.z);
                    rBody.transform.Translate(0, 0, -horizontal);
                    anim.SetBool("Waking", true);
                    idleTimer = 0;
                    anim.SetBool("Block", false);


                }

                //Ativa animação de caminhar
                else if (horizontal > 0)
                {
                    gameObject.transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, 90, transform.localEulerAngles.z);
                    rBody.transform.Translate(0, 0, horizontal);
                    anim.SetBool("Waking", true);
                    idleTimer = 0;
                    anim.SetBool("Block", false);
                }


                //Desativa animação de caminhar
                if (horizontal == 0)
                {
                    anim.SetBool("Waking", false);
                }



                if (onGround)
                {
                    anim.SetBool("onGround", true);
                    // Make it Jump
                    if (Input.GetKeyDown(Jump) && (JumpDelay == false))
                    {
                        JumpDelay = true;
                        rBody.velocity = new Vector3(0, jumpVelocity, 0) * Time.deltaTime;
                        anim.SetTrigger("Jump");
                        idleTimer = 0;
                    }


                    if (Input.GetKeyDown(Action2))
                    {
                        anim.SetBool("Block", true);
                        timedBlockStatus = 1;

                    }
                     if (Input.GetKeyUp(Action2))
                    {
                        anim.SetBool("Block", false);
                        idleTimer = 0;
                        timedBlockStatus = 0;
                        takeDamageTimer = 2;
                        isBlocking = false;
                    }


                }
                //Atualiza pro animator se o player não está no chao
                else if (!onGround) anim.SetBool("onGround", false);

            }

        }
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        //Faz o player tomar dano acessando o EnemyScript
        if (other.tag == "EnemyDamage")
        {
            _enemyScript = other.gameObject.GetComponentInParent<EnemyScript>();
            _damageScript.TakeDamage();

        }
        if (other.gameObject.tag == "Collect")
        {

        }
    }

    private void OnTriggerStay(Collider other)
    {
        //Desativa o efeito Parallax
        if (other.gameObject.tag == "StopParallax")
        {
            deactivateParallax = true;
        }
        //Ângulos de camera
        if (other.gameObject.tag == "Camera Angle")
        {
            _cameraScript.CameraAngle1();
            deactivateParallax = true;
        }
        if (other.gameObject.tag == "Camera Angle 2")
        {
            _cameraScript.CameraAngle2();
            deactivateParallax = true;
        }
        if (other.gameObject.tag == "Camera Angle 3")
        {
            _cameraScript.CameraAngle3();
            deactivateParallax = true;
        }
        //Ativa os efeitos da areia movediça
        if (other.gameObject.tag == "Quicksand")
        {
            deactivateParallax = true;
            anim.SetTrigger("Quicksand");
            QuickSand = true;
            rBody.velocity = new Vector3(0,0,0);
            deadtimer = true;
            if (timerdead >= 3)
            {
                hitPoints -= 100;
                deadtimer = false;
            }
        }
        if (other.gameObject.tag == "DamageMechanic")
        {
            deactivateParallax = true;
            deadtimer = true;
            if (timerdead >= 0.2)
            {
                hitPoints -= 100;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraScript>().CA = false;
        deactivateParallax = false;
      //  _cameraScript.CA = false;
    }

    //Método responsavel pelo delay do roll
    public virtual void MethodRollDealy()
    {

        if (timerRoll >= 1.5f)
        {
            RollDelay = false;
            timerRoll = 0;
        }
      
    }
    //Mestre do Input de Ataque
    public virtual void AttackInput()
    {

    }
    //Método de Bloqueio Preciso
    void Timedblock()
    {     
          Immune = true;
    }
}
