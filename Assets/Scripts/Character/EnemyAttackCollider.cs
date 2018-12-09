using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Script para ativar o collider de ataque apenas quando atacar
public class EnemyAttackCollider : MonoBehaviour {
    [SerializeField]
    SphereCollider Stinger;

    void AttackCollider()
    {
        Stinger.enabled = true;

    }

    void UnttackCollider()
    {
        Stinger.enabled = false;

    }
}
