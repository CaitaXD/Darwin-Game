using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour {

    public Image hpBar;
    Color verdeLindo = new Color();
    [SerializeField]
    float lerpSpeed = 12;
    // Use this for initialization
    void Start ()
    {

    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        hpBar.fillAmount = Mathf.Lerp(hpBar.fillAmount, GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>().hitPoints / 100, Time.deltaTime * lerpSpeed);
    
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
