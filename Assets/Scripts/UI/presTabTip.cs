using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Script que faz um ''press tab to fuse'' aparecer no canto
public class presTabTip : MonoBehaviour {
 
    public GameObject TabButton;
    Character _c;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        _c = GetComponent<Character>();
	}
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && _c.isDead == true)
        {
            TabButton.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            TabButton.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            TabButton.SetActive(false);
        }
    }
}
