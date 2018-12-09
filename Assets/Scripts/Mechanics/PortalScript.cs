using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalScript : MonoBehaviour {
    [SerializeField]
    GameObject OuterPortal;
    private void Start()
    {
      
    }
    private void FixedUpdate()
    {
   
        transform.eulerAngles += new Vector3(0, 0, 1);
        OuterPortal.transform.eulerAngles += new Vector3(0, 0, -2);


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene("DesertPartOne", LoadSceneMode.Single);
            Destroy(GameObject.FindGameObjectWithTag("Info"));
        }
    }
}
