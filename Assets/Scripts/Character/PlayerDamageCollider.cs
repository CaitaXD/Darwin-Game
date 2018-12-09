using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageCollider : MonoBehaviour {
    public SphereCollider damageCollider;
    public GameObject tabButton;

	void ColliderActivate()
    {
        //Ativa o collider de dano
        damageCollider.enabled = true;
    }

    void ColliderDeactivate()
    {
        //Desativa o collider de dano
        damageCollider.enabled = false;
    }

    void TabDeactivate()
    {
        //Desativa a hint do ''tab to fuse''
        tabButton.SetActive(false);
    }
}
