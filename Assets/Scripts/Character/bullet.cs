using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {
    public float velocity, damage;
    float timer = 0;
	// Use this for initialization
	void Start () {
      
	}
	
	// Update is called once per frame
	void FixedUpdate () {
            transform.Translate(0, 0, velocity);  
	}
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
