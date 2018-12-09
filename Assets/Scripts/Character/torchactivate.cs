using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torchactivate : MonoBehaviour {
    public GameObject player;
    public GameObject lantern;
    public bool isytype;
    public bool isiniciallight;
	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        //Verifica se é do tipo luz inicial (luz que precisa de mais range para desativar)
        if (isiniciallight == false)
        {
            //Ativa / Desativa as Luzes 
            if (Vector3.Distance(new Vector3(player.transform.position.x, 0, 0), new Vector3(this.transform.position.x, 0, 0)) > 35)
            {
                lantern.SetActive(false);
            }
            else if (Vector3.Distance(new Vector3(player.transform.position.x, 0, 0), new Vector3(this.transform.position.x, 0, 0)) < 35)
            {
                lantern.SetActive(true);
            }
        }
        //Verifica se é do tipo luz inicial (luz que precisa de mais range para desativar)
        if (isiniciallight == true)
        {
            //Ativa / Desativa as Luzes
            if (Vector3.Distance(new Vector3(player.transform.position.x, 0, 0), new Vector3(this.transform.position.x, 0, 0)) > 75)
            {
                    lantern.SetActive(false);
            }
            else if (Vector3.Distance(new Vector3(player.transform.position.x, 0, 0), new Vector3(this.transform.position.x, 0, 0)) < 75)
            {
                lantern.SetActive(true);
            }
        }
    }
}
