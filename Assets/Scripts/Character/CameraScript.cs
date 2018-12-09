using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {
    public Camera MainCamera;
    public GameObject playerPosition;
    public Vector3 offset;
    public bool CA;
    public Transform CA1,CA2,CA3;
    // Use this for initialization
    void Start()
    {
        MainCamera = Camera.main;
        CA = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player");
        //Se não estiver em algum ângulo de câmera, ele fixa a posição da camera no player com um offset smooth
        if (CA == false)
        {
            //Se o player for muito rápido a camera acompanha ele
            if (Vector3.Distance(new Vector3(playerPosition.transform.position.x,0,0), new Vector3(this.gameObject.transform.position.x,0,0)) >= 6.80)
            {
                this.gameObject.transform.position = Vector3.Lerp(this.gameObject.transform.position, playerPosition.transform.position + offset, 0.18f);
            }
            else
            {
                this.gameObject.transform.position = Vector3.Lerp(this.gameObject.transform.position, playerPosition.transform.position + offset, 0.06f);
            }
            offset = new Vector3(5f,1.2f,-18f);
        }
	}

    public void CameraAngle1()
    {
        CA = true;
        offset = new Vector3(-1f, 1.3f, -25f);
        //this.gameObject.transform.position = new Vector3(80f, 1.24369f, -25f);
        this.gameObject.transform.position = Vector3.Lerp(this.gameObject.transform.position,CA1.transform.position + offset ,0.06f);
    }

    public void CameraAngle2()
    {
        CA = true;
        offset = new Vector3(-0.58f, 1.2f, -22.6f);
        //this.gameObject.transform.position = new Vector3(123.795f, -13.97f, -28f);
        this.gameObject.transform.position = Vector3.Lerp(this.gameObject.transform.position, CA2.transform.position + offset, 0.06f);
    }

    public void CameraAngle3()
    {
        CA = true;
        offset = new Vector3(0f, 0.8f, -17f);
        this.gameObject.transform.position = Vector3.Lerp(this.gameObject.transform.position, playerPosition.transform.position + offset, 0.06f);
        
    }
}

