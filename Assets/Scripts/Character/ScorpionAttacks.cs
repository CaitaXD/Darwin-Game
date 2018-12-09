using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorpionAttacks : EnemyScript
{
    //Override de ataque do escorpião (por que todos inimigos tem diferentes tipos de ataques)
  public override void Attack()
    {
        damage = damage1;
        if (timer >= 2f)
        {
            anim.SetTrigger("AttackTail");
            timer = 0;
        }
    }
  
}
