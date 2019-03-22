using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TweakedInputs : PlayerScript
{
    [SerializeField]
    public float damage1, damage2, damage3;

    public override void MethodRollDealy ()
    {
        //O roll delay é utilizado como delay de ataque
        if (timerRoll >= 0.5f)
        {
            RollDelay = false;
            timerRoll = 0;
        }
    }
 
    
    public override void AttackInput()
    {
        //ataque de rabo
        if (Input.GetKeyDown(Action1) && (RollDelay == false))
        {
            anim.SetBool("Sleep", false);
            MethodRollDealy();
            anim.SetTrigger("attack");
            _damageScript.damage = damage1;
          idleTimer = 0;
            idleTimer = 0;
           
        }
        //ataque de garra
        if (Input.GetKeyDown(Action3) && (RollDelay == false))
            {
            anim.SetBool("Sleep", false);
            MethodRollDealy();
            anim.SetTrigger("attack2");
           _damageScript.damage = damage3;
           idleTimer = 0;
            idleTimer = 0;

        }

    }
}


