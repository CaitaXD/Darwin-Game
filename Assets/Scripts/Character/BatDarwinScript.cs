using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatDarwinScript : PlayerScript {
  
    [SerializeField]
    public float damage1, damage2, damage3;
    float timer = 0;



    public override void FixedUpdate()
    {

        base.FixedUpdate();
        timer += Time.deltaTime;
        //Reseta o fly da fusao bat enquanto estiver no chao
        if (onGround)
        { 
           anim.SetBool("Planing", false);
        }
    }

    public override void AttackInput()

    {
        if (QuickSand == false)
        {

            //Fly Attack
            if (!onGround)
            {
                if (Input.GetKeyDown(KeyCode.R) && (RollDelay == false))
                {
                    if (GameObject.FindGameObjectWithTag("Enemy") != null)
                        transform.LookAt(GameObject.FindGameObjectWithTag("Enemy").transform);
                    anim.SetBool("Sleep", false);
                    RollDelay = true;
                    rBody.velocity += transform.forward *rollVelocity;   
                    anim.SetTrigger("Dash");
                    _damageScript.damage = damage1;
                idleTimer = 0;
                    transform.eulerAngles = ResetEuler;

                }
                //Fly da fusao bat darwin
                if (Input.GetKeyDown(KeyCode.Space) && (JumpDelay == false))
                {
                    anim.SetBool("Planing", true);
                    gravity -= 55;
                    JumpDelay = true;
                    rBody.velocity = Vector3.zero;
                
                    
                }
                //Imoede que a gravidade fique negativa
                if (Input.GetKey(KeyCode.Space))
                {
                    if (timer >= 1.5f)
                        gravity += 3;
                }

            }
            //Imoede que a gravidade fique negativa
            if (Input.GetKeyUp(KeyCode.Space))
            {
                gravity = 60;
                timer = 0;
                




            }
            //Ataque do bat fusion
            if (onGround)
            {
                if (Input.GetKeyDown(KeyCode.R) && (RollDelay == false))
                {
                    anim.SetBool("Sleep", false);
                    anim.SetTrigger("Bite");
                    RollDelay = true;
                    _damageScript.damage = damage1;
                    idleTimer = 0;
                }
            }
        }
    }

}
