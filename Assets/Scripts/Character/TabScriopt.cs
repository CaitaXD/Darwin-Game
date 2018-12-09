using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabScriopt : MonoBehaviour {

    [SerializeField]
    GameObject tab;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Faz o ''tab to fuse'' aparecer no canto
		if (gameObject.tag == "Dead")
        {
            tab.SetActive(true);
        }else tab.SetActive(false);
    }
}
