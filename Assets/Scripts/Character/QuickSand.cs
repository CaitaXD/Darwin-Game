using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickSand : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        //Faz a animação de quicksand e previne o player de se movimentar 
        if (other.gameObject.tag == "Quicksand")
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>().QuickSand = true;
        }
    }
}
