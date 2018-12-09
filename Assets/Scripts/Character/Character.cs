using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Rigidbody rBody;
    public Animator anim;
    public LayerMask whatisGround;
    public Transform groundPoint;
    public float hitPoints, walkVelocity, jumpVelocity, gravity;
    public bool onGround;
    public bool isDead;
    public bool Immune;
    protected bool isBlocking;
    protected float takeDamageTimer;
    protected float FixedZ;
    RaycastHit GroundFinder;
    int LayerMask = 8; 

    public virtual void Start ()
    {
        isBlocking = false;
        FixedZ = transform.position.z;
    }
    public virtual void FixedUpdate ()
    {
        Dead();
      //  CollisionSystem();
        transform.position = new Vector3(transform.position.x, transform.position.y, FixedZ);
    }
    protected void KYS()
    {
        if (hitPoints <= 0)
            isDead = true;
        if (isDead) GameObject.Destroy(gameObject);

    }
    //Muda a tag do gameobject para dead e inicia a animação
    protected void Dead()
    {
        if (hitPoints <= 0)
        {
            isDead = true;
            if (isDead)
            {
                if (GetComponentInChildren<SkinnedMeshRenderer>() != null)
                GetComponentInChildren<SkinnedMeshRenderer>().enabled = true;
                gameObject.tag = "Dead";
                anim.SetBool("isDead", true);
                anim.SetBool("Walk", false);
            }
            if (gameObject.tag == "Dead" && GetComponentInChildren<ParticleSystem>() != null)
                GetComponentInChildren<ParticleSystem>().Stop();


        }
    }
    //Método que deixa o character imune apos levar dano ou bloquear
    public virtual void ImmunityeMethod()
    {
        if (Immune == true)
        {
            takeDamageTimer += Time.deltaTime;
            if (isBlocking == false)
            {
                PiscaPisca();
            }
        }

        if (takeDamageTimer >= 0.5f)
        {
            if (GetComponentInChildren<SkinnedMeshRenderer>() != null)
            GetComponentInChildren<SkinnedMeshRenderer>().enabled = true;
            Immune = false;
            takeDamageTimer = 0f;
        }
    }

    public void CollisionSystem()
    {
        Debug.DrawRay(transform.position, -transform.up, Color.gray, 2);
       if (Physics.Raycast(transform.position,-transform.up,out GroundFinder,0.1f))
        {
            transform.position = GroundFinder.point;
        }
    }

    //Método que faz o efeito pisca de dano
    void PiscaPisca()
    {
        if (GetComponentInChildren<SkinnedMeshRenderer>() != null && GetComponentInChildren<SkinnedMeshRenderer>().enabled == false)
        {
            GetComponentInChildren<SkinnedMeshRenderer>().enabled = true;
        }
        else
        {
            if (GetComponentInChildren<SkinnedMeshRenderer>() != null)
            GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
        }
    }
}
