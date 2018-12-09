using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorScript : MonoBehaviour
{
    Rigidbody platBody;
   public  int platDirection;
    bool isPlatMoving;
    // Update is called once per frame
    private void Start()
    {
        platBody = GetComponent<Rigidbody>();
        isPlatMoving = false;
    }
    private void FixedUpdate()
    {

        if (isPlatMoving)
        {
            switch (platDirection)
            {
                case (1):
                    platBody.velocity = new Vector3(0, 5, 0);
                    break;
                case (-1):
                    platBody.velocity = new Vector3(0, -5, 0);
                    break;
            }
        }
        else platBody.velocity = new Vector3(0, 0, 0);
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Up")
        {
            platDirection = 1;
            isPlatMoving = false;
        }
        else if (other.gameObject.tag == "Down")
        {
            platDirection = -1;
            isPlatMoving = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.Space))
            isPlatMoving = true;
      
    }
    
}