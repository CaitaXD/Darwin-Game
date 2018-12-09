using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightAura : MonoBehaviour {

    GameObject player;

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        gameObject.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 1.6f, player.transform.position.z);
	}
}
