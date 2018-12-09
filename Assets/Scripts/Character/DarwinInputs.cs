using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarwinInputs : PlayerScript {
    
    [SerializeField]
    public float damage1, damage2, damage3;

  
    //Método de ataque
    public override void AttackInput()
    {
        //Confere areia movediça
        if (QuickSand == false)
        {
            if (onGround)
            {   //Make it Roll
                if (Input.GetKeyDown(KeyCode.R) && (RollDelay == false))
                {
                    anim.SetBool("Sleep", false);
                    damagecollider.enabled = true;
                    RollDelay = true;
                    rBody.velocity += transform.forward * rollVelocity * Time.deltaTime;
                    anim.SetTrigger("Roll");
                    _damageScript.damage = damage1;
                    idleTimer = 0;


                }

            }
            //Confere se o player está no ar
            else if (!onGround)
            {
                //Make it Stomp
                if (Input.GetKeyDown(KeyCode.T))
                {
                    rBody.velocity = new Vector3(0, stompVelocity, 0) * Time.deltaTime;
                    anim.SetTrigger("Stomp");
                    _damageScript.damage = damage2;
                    idleTimer = 0;
                }
            }
            
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        //Se o player possuir certa velocidade quando atacar o inimigo leva um knockback
        if (other.gameObject.tag == "Enemy")
       if (rBody.velocity.x > 5 || rBody.velocity.y < -5)
                { 
                rBody.velocity = new Vector3(-12, 16, 0);
                    }
    }
}
