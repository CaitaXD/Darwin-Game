using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstalactiteScript : MonoBehaviour {

    Rigidbody rbody;
    public GameObject player;
    public AudioSource fallsound;

    private void Start()
    { 
        rbody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        if (player.transform.position.y < -30)
        {
            if (Vector3.Distance(new Vector3(player.transform.position.x, 0, 0), new Vector3(this.transform.position.x, 0, 0)) < 9)
            {
                this.rbody.isKinematic = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.GetComponent<PlayerScript>().hitPoints -= 10;
            fallsound.Play();
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionStay(Collision collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            fallsound.Play();
            Destroy(this.gameObject);
        }
    }

}
