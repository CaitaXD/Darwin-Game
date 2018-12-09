using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowScriptOptionsmenu : MonoBehaviour {
    [SerializeField]
    Animator anim;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow)) anim.SetTrigger("DowArrow");
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow)) anim.SetTrigger("Uparrow");
    }
}
