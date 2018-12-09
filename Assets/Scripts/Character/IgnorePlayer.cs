using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnorePlayer : MonoBehaviour {
    [SerializeField]
    Collider Collider1,Collider2;
    private void OnCollisionEnter(Collision collision)
    {
        Physics.IgnoreCollision(GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>(),Collider1);
        Physics.IgnoreCollision(GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>(), Collider2);
    }
}
