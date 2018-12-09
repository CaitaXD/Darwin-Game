using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour {

    GameObject player;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        //Para o efeito parallax parar ao tocar em alguma parede
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>().deactivateParallax == false)
        {
            //Faz o efeito Parallax
            if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>().horizontal > 0)
            {
                if (this.gameObject.tag == "BC1")
                {
                    this.gameObject.transform.position += new Vector3(-0.03f, 0f, 0f);
                }
                if (this.gameObject.tag == "BC2")
                {
                    this.gameObject.transform.position += new Vector3(-0.09f, 0f, 0f);
                }
            }
            //Faz o efeito Parallax
            if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>().horizontal < 0)
            {
                if (this.gameObject.tag == "BC1")
                {
                    this.gameObject.transform.position += new Vector3(0.03f, 0f, 0f);
                }
                if (this.gameObject.tag == "BC2")
                {
                    this.gameObject.transform.position += new Vector3(0.09f, 0f, 0f);
                }
            }
        }
    }
}
