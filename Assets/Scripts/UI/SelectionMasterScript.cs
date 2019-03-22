using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionMasterScript : MonoBehaviour {
    [SerializeField]
    AudioClip selectionSound;
    [SerializeField]
    AudioSource menuAudio;
    [SerializeField]
    float lerpSpeed;
    [SerializeField]
    int cicleAtSlotX;
    [SerializeField]
  protected int selectionIs = 1;
    [SerializeField]
    Transform selectionArrow;
    [SerializeField]
    Transform slot1,slot2,slot3,slot4,slot5;
    float y1, y2, y3, y4, y5;
    float arrowY;
    [SerializeField]
   protected SelectionMasterScript iD1;
    AudioReader _audioReader;
    // Use this for initialization
    virtual protected void Start () {
        arrowY = selectionArrow.position.y;
        if (slot1 != null)
            y1 = slot1.position.y;
        if (slot2 != null)
            y2 = slot2.position.y;
        if (slot3 != null)
            y3 = slot3.position.y;
        if (slot4 != null)
            y4 = slot4.position.y;
        if( slot5 !=null)
        y5 = slot5.position.y;
        if (GameObject.FindGameObjectWithTag("AudioReader") == null) { }
        else
        {
            _audioReader = GameObject.FindGameObjectWithTag("AudioReader").GetComponent<AudioReader>();
            menuAudio.volume = _audioReader.batlleSounds;
        }

    }
	
	// Update is called once per frame
	virtual protected void Update () {
        if (selectionIs > cicleAtSlotX)
            {
                selectionIs = 1;
            }
            if (selectionIs < 1)
            {
                selectionIs = cicleAtSlotX;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                selectionIs += 1;
            menuAudio.PlayOneShot(selectionSound);
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                selectionIs -= 1;
                menuAudio.PlayOneShot(selectionSound);
                menuAudio.Play();
            }

        if (selectionArrow != null)
        {
            switch (selectionIs)
            {
                case 1:
                    arrowY = Mathf.Lerp(arrowY, y1, Time.unscaledDeltaTime * lerpSpeed);
                    selectionArrow.position = new Vector3(selectionArrow.position.x, arrowY, 0);

                    case1();

                    break;
                case 2:
                    arrowY = Mathf.Lerp(arrowY, y2, Time.unscaledDeltaTime * lerpSpeed);
                    selectionArrow.position = new Vector3(selectionArrow.position.x, arrowY, 0);

                    case2();

                    break;
                case 3:
                    arrowY = Mathf.Lerp(arrowY, y3, Time.unscaledDeltaTime * lerpSpeed);
                    selectionArrow.position = new Vector3(selectionArrow.position.x, arrowY, 0);

                    case3();

                    break;
                case 4:
                    arrowY = Mathf.Lerp(arrowY, y4, Time.unscaledDeltaTime * lerpSpeed);
                    selectionArrow.position = new Vector3(selectionArrow.position.x, arrowY, 0);

                    case4();

                    break;
                case 5:
                    arrowY = Mathf.Lerp(arrowY, y5, Time.unscaledDeltaTime * lerpSpeed);
                    selectionArrow.position = new Vector3(selectionArrow.position.x, arrowY, 0);

                    break;
            }
        }        


	}
    protected virtual void case1()
    {
      
    }
    protected virtual void case2()
    {

    }
    protected virtual void case3()
    {

    }
    protected virtual void case4()
    {

    }
    protected virtual void case5()
    {

    }
}
