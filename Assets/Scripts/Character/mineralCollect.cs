using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mineralCollect : MonoBehaviour {

    Animator mineranim;
    bool istriggered = false;
    public Text numberCol;
    public int number = 0;

    // Use this for initialization
    void Start ()
    {
        mineranim = GetComponent<Animator>();
        numberCol = GameObject.FindGameObjectWithTag("ChangeColl").GetComponentInChildren<Text>();
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {

	}
    //Destrói o coletavel
    void Delete()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>().collectOnce = false;
        //istriggered = false;
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Coleta o coletavel
            if (istriggered == false)
            {
                mineranim.SetTrigger("collected");
                GameObject.FindGameObjectWithTag("Info").GetComponent<PlayerInfo>().number += 1;
                numberCol.text = ("" + GameObject.FindGameObjectWithTag("Info").GetComponent<PlayerInfo>().number);
                GameObject.FindGameObjectWithTag("ChangeColl").GetComponent<Animator>().SetTrigger("fade");
                istriggered = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //if (other.gameObject.tag == "Player")
        //{
        //    istriggered = false;
        //}
    }
}
