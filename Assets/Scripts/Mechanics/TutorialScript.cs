using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : PlayerInfo {
    [SerializeField]
    float timer;
    [SerializeField]
    bool timeractivate;
    public Vector3 SpawnPoint;
    Transform player;

    // Use this for initialization
    void Start () {
        //Restringe os botoes do player
        tutorialRestrictions = true;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        SpawnPoint = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
    }
	
	// Update is called once per frame
	public override void FixedUpdate () {

        if (timeractivate == true)
        {
            timer += Time.deltaTime;
        }
        if (timer >= 0.5f)
        {
            
            player.transform.position = SpawnPoint + new Vector3(0, 25, 0);
            SpawnPoint = player.transform.position;
            timer = 0;
            timeractivate = false;
            
        }
        if (cheknewID != checkID)
        {
            timeractivate = true;
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
           
        }
        base.FixedUpdate();
        }
  
  
}
