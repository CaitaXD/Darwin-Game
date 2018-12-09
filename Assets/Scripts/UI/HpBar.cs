using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour {

    public Image hpBar;
    Color verdeLindo = new Color();
    // Use this for initialization
    void Start ()
    {

    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (hpBar.fillAmount != GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>().hitPoints)
        {
            hpBar.fillAmount = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>().hitPoints / 100;
        }
        ColorUtility.TryParseHtmlString("#32CD32", out verdeLindo);
        if (hpBar.fillAmount >= 0.6f)
        {
            hpBar.color = verdeLindo;
        }
        if (hpBar.fillAmount >= 0.2f && hpBar.fillAmount <= 0.6f)
        {
            hpBar.color = Color.yellow;
        }
        if (hpBar.fillAmount <= 0.2f)
        {
            hpBar.color = Color.red;
        }
    }
}
