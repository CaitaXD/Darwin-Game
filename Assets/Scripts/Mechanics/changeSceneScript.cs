using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeSceneScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && this.gameObject.tag == "Cave2")
        {
            SceneManager.LoadScene("DesertPartTwo", LoadSceneMode.Single);
        }
        if (other.gameObject.tag == "Player" && this.gameObject.tag == "Cave1")
        {
            SceneManager.LoadScene("Cave1", LoadSceneMode.Single);
        }
        if (other.gameObject.tag == "Player" && this.gameObject.tag == "ENDDEMO")
        {
            SceneManager.LoadScene("Credits", LoadSceneMode.Single);
            Destroy(GameObject.FindGameObjectWithTag("Info"));
        }
    }
}
