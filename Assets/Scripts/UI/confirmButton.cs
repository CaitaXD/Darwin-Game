using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class confirmButton : MonoBehaviour {

	public void DoIt()
    {
        SceneManager.LoadScene("Menu Inicial");
    }
}
