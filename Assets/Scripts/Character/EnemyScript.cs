using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : Character {
    protected DamageScript _DamageScript;
    protected GameObject player;
    [SerializeField]
    protected float damage1, damage2, damage3;
    public float damage;
    [SerializeField]
    protected GameObject Waypoint1, Waypoint2;
    protected float timer;
    protected  RaycastHit hit;
    protected RaycastHit hit2;
    float takeDamageTimer;
    [SerializeField]
	protected int State;
	[SerializeField]
	protected float attackDistance;
    [SerializeField]
    protected float backUpDistance;
    [SerializeField]
    Collider col1;
    [SerializeField]
    float RaycastOffset1 = 0.75f, RaycastOffset2 = 0.5f;
    [SerializeField]
    float RaycastOffsetx;
    public GameObject stunPref;
    public GameObject stunObj;
    public bool stunSpawnOnce;
   protected AudioReader _audioReader;
   


    // Use this for initialization
    public new virtual void Start () {
        base.Start();

        if (GameObject.FindGameObjectWithTag("AudioReader") == null) { }
        else
        {
            _audioReader = GameObject.FindGameObjectWithTag("AudioReader").GetComponent<AudioReader>();
        }
        anim = GetComponentInChildren<Animator> ();
        rBody = GetComponent<Rigidbody>();
        player =  GameObject.FindGameObjectWithTag("Player");
        _DamageScript = player.GetComponent<DamageScript>();
        stunSpawnOnce = true;

    }

   public new  virtual void FixedUpdate()
	{
        attackDistance = _audioReader.enemyRangeMod;
        //Quando o inimigo morre, as ações são executadas
        if (gameObject.tag == "Dead")
        {
            anim.SetBool("Dead", true);
            if (col1 != null)
            col1.gameObject.SetActive(false);
            //Spawna o efeito de stun no inimigo
            if (stunSpawnOnce == true && stunPref != null)
            {
                stunObj = Instantiate(stunPref, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.02f, gameObject.transform.position.z), new Quaternion(0, 0, 0, 0));
                stunSpawnOnce = false;
            }
            //Se o stun sair de posição, ele volta pra posição que precisa estar
            if (stunObj.transform.position != new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.02f, gameObject.transform.position.z) && stunObj != null)
            {
                stunObj.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.02f, gameObject.transform.position.z);
            }
        }
        base.FixedUpdate();
        ImmunityeMethod();
 
        if (Immune == true)
        {
            takeDamageTimer += Time.deltaTime;
        }

        if (takeDamageTimer >= 2f)
        {
            Immune = false;
            takeDamageTimer = 0f;
        }
        if (player == null)
        player = GameObject.FindGameObjectWithTag("Player");
        StateMachine();
      
        Dead();
       



        rBody.AddForce(new Vector3(0, -gravity, 0));
        timer += Time.deltaTime;

        
	}
    //Método de Patrol
    public virtual void Patrol() 
    {
        if (Waypoint1 != null)
        {
            if (timer <= 4) Walk();
            if (timer >= 6) timer = 0;

            if (transform.position.x  >= Waypoint2.transform.position.x) rBody.transform.eulerAngles = new Vector3(0, 270, 0);
            if (transform.position.x  <= Waypoint1.transform.position.x) rBody.transform.eulerAngles = new Vector3(0, 90, 0);
        }
        else { }

    }
    //Método de Chase
     public virtual void Queijo()
    {
        if (isDead == false)
        {
            if (transform.position.x -1.5f>= player.transform.position.x) rBody.transform.eulerAngles = new Vector3(0, 270, 0);
            if (transform.position.x +1.5f<= player.transform.position.x) rBody.transform.eulerAngles = new Vector3(0, 90, 0);
            Walk();
        }
    }
    //Método de Andar
	public virtual void Walk ()
	{
        if (isDead == false)
        {
            anim.SetBool("Walk", true);
            transform.Translate(0, 0, 0.11f* _audioReader.enemySpeedMod);
        }
	}
    //Método de ataque (override pelos inimigos devido a cada um ter uma maneira de atacar)
	virtual public void Attack ()
	{
		
	}

    protected void TakeDamge()
    {
        
    }

   //Define em qual estado o inimigo se encontra
    public virtual void StateMachine ()
    {
        
        Debug.DrawRay(new Vector3(transform.position.x+ RaycastOffsetx, RaycastOffset1 + transform.position.y, transform.position.z), transform.forward, Color.red);
        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + RaycastOffset2, transform.position.z), transform.up, Color.red);
        switch (State)
        {
            case 0:
                //Lança um raycast que quando bate no player muda para o proximo estado
                if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y + RaycastOffset2, transform.position.z), transform.up, out hit, 20))
                {
                    if (hit.collider.tag == "Player")
                        State = 1;
                }
                //Lança um raycast que quando bate no player muda para o proximo estado
                if (Physics.Raycast(new Vector3(transform.position.x + RaycastOffsetx, transform.position.y + RaycastOffset1, transform.position.z), transform.forward, out hit, 10))
                {

                    if (hit.collider.tag == "Player")
                        State = 1;
                }
                Patrol();
                break;
            case 1:

                Queijo();
           //     if (Physics.Raycast(new Vector3(transform.position.x,0.75f+ transform.position.y, transform.position.z), transform.forward, out hit,attackDistance))
             //       if (hit.collider.tag == "Player")
                //    State = 2;
                //Se o player se afastar muito volta para o estado 0
                if (Vector3.Distance(player.transform.position, transform.position) > 20)
                    State = 0;
              //  if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y+ 0.5f, transform.position.z), transform.up,out hit2,attackDistance))
               // {
                 //   if (hit2.collider.tag == "Player")
                 //       State = 2;

              //  }
               
                break;
            case 2:
                int key0 = 0;
                int key1 = 0;
                Attack();
                //Lança um raycast que quando bate no player ele permanece atacando
                if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y + RaycastOffset2, transform.position.z), transform.up, out hit2, attackDistance))
                {
                    if (hit2.collider.tag == "Player")
                        key0 = 1;
                   else key0 = 0;
                } else key0 = 0;
                //Lança um raycast que quando bate no player ele permanece atacando
                if (Physics.Raycast(new Vector3(transform.position.x+ RaycastOffsetx, transform.position.y+ RaycastOffset1, transform.position.z), transform.forward, out hit, attackDistance))
                {
                    if (hit.collider.tag == "Player")
                        key1 = 1;
                  else  key1 = 0;
                }else key1 =0;
                //Se nenhum Raycast estiver Batendo no player Volta Para o Estado de Chase
                if (key0 ==0 && key1 == 0)
                    State = 1;
                break;
        }
      





    }
    private void OnCollisionStay(Collision other)
    {

        if (isDead)
            Physics.IgnoreCollision(GetComponent<Collider>(), player.GetComponent<Collider>());

        if (other.gameObject == player) State = 2;
    }
   


}

