using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Basicamente o enemyscript mas mudado para usar com inimigos voadores
public class MorcegoInputs : EnemyScript{
    Transform Defaultposition;
    public AudioSource Squeak;

    public override void StateMachine()
    {

        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y, transform.position.z), -transform.up, Color.green);


        switch (State)
        {
            case 0:

                Patrol();
                if (Vector3.Distance(player.transform.position, transform.position) > 10)
                {
                    State = 1;
                }
                break;
            case 1:

                Queijo();
                if (Vector3.Distance(player.transform.position, transform.position) < attackDistance)
                {
                    State = 2;

                }
                break;
            case 2:
                rBody.velocity = Vector3.zero;
                transform.LookAt(player.transform.position, player.transform.eulerAngles);

                Attack();
                if (Vector3.Distance(player.transform.position, transform.position) > 1.5f)
                {
                    transform.Translate(0, 0, 0.11f);
                }
                if (Vector3.Distance(player.transform.position, transform.position) > 10)
                {
                    State = 3;
                }
                break;
            case 3:
                transform.Translate(0, walkVelocity, -walkVelocity);
                if (Vector3.Distance(player.transform.position, transform.position) > 10)
                {
                    State = 1;
                }


                break;
            case 4:
                rBody.AddForce(new Vector3(0, -60, 0));
                break;

        }
    
        
       

        if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y, transform.position.z), -transform.up, out hit))
        {
            if (hit.collider)
            { Debug.Log(hit.collider.gameObject.tag); }
           if (hit.collider.tag == "Player")
            {
                State = 1;
            }
        }
        if (Vector3.Distance(player.transform.position, transform.position) > 20)
        {
            timer = 0;
            if (isDead == false)
            State = 0;

        }
    }
    public override void Attack()
    {
        anim.SetTrigger("Bite");
        damage = damage1*_audioReader.enemyDamageMod;
          
        
    }
    public override void Queijo()
    {
            anim.SetBool("WakeUp", true);
            transform.LookAt(player.transform.position, player.transform.eulerAngles);
            Walk();
    }
    public override void Walk()
    {
       
        if (!isDead)
        {
            float z = 0.6f;
            float y = 1f;

            y = y - y / 4;
            z = z + z / 4;
        
            transform.Translate(0,-y*_audioReader.enemySpeedMod, z*_audioReader.enemySpeedMod);
         
           

        }

    }
    public override void Patrol()
    {
            //Morcego só sai do idle se ele ver o player
            //anim.SetBool("WakeUp", false);
            transform.eulerAngles = Defaultposition.eulerAngles;
        
    }
 
  public override void Start()
    {
        Defaultposition = this.transform;
        base.Start();
       
    }
    public override void FixedUpdate()
    {
        base.FixedUpdate();
        if (isDead == true)
        {
            State = 4;
        }
        
           
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerDamage")
        {
            State = 3;
            if (!isDead)
            {
                Squeak.Play();
            }
        }
        else if (other.gameObject.tag == "Player") State = 2;
         

    }
    private void OnCollisionEnter(Collision other)
    {

       
    }
}

