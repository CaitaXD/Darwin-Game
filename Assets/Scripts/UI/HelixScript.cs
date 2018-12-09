using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixScript : MonoBehaviour {
    [SerializeField]
    Animator anim;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.RightArrow ) || Input.GetKeyUp(KeyCode.UpArrow)) anim.SetTrigger("HelixMoveright");
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.DownArrow)) anim.SetTrigger("HelixMoveLeft");
    }
}
