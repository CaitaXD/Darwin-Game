using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Serve para teleportar o player para as outras partes do tutorial
public class TeleportScript : MonoBehaviour {
    [SerializeField]
    Transform player;
    TutorialScript _tutorialScript;
	// Use this for initialization
	void Start () {
        _tutorialScript = GameObject.FindGameObjectWithTag("Info").GetComponent<TutorialScript>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _tutorialScript.SpawnPoint = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        
	}

    private void OnTriggerEnter(Collider other)
    {
     
        if(other.gameObject.tag == "Player")
        {
            other.GetComponent<Rigidbody>().velocity = Vector3.zero;
            other.gameObject.transform.position = _tutorialScript.SpawnPoint; }
    }
}
