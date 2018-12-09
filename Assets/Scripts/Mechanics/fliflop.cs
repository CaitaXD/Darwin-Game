using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fliflop : MonoBehaviour {
    [SerializeField]
    GameObject master;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.rotation = new Quaternion(transform.rotation.x, master.transform.rotation.y/800000, transform.rotation.z,-master.transform.rotation.w);
    
    }
}
