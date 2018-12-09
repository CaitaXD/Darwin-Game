using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsEnd : MonoBehaviour {

    float timerExit;

	void Awake ()
    {
		
	}
	
	void Update ()
    {
        timerExit += Time.deltaTime;

        //Quando o timer estiver maior que 5, os jogo fecha
        if(timerExit >= 5)
        {
            Application.Quit();
        }
	}
}
