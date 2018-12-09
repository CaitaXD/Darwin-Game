using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slotfusion : MonoBehaviour {
    Text slot;
    int id;
    PlayerInfo _playerinfo;
   

    // Use this for initialization
    void Start () {
    
    }
	
	// Update is called once per frame
	void Update () {
        id = GameObject.FindGameObjectWithTag("Info").GetComponent<PlayerInfo>().checkID;

        if (id == 1) slot.text = "Darpion";

	}
}
