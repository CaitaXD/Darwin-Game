using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortraitScript : MonoBehaviour {
    Image portrait;
    [SerializeField]
    Sprite Darwinprotrait, Darpionportrait, BatDarwinPortrait;
    [SerializeField]
    Sprite a99, b99, a1, b1, a2, b2,none;
    PlayerInfo _playerinfo;
    [SerializeField]
    Image a,b;
	// Use this for 1initialization
	void Start () {
        _playerinfo = GameObject.FindGameObjectWithTag("Info").GetComponent<PlayerInfo>();
        portrait = GetComponent<Image>();
	}
	
	// Muda os portraits na UI do jogo
	void Update () {
        switch (_playerinfo.checkID)
        {
            case 99:
                portrait.sprite = Darwinprotrait;
                a.sprite = a99;
                b.sprite = b99;
                break;
            case 1:
                portrait.sprite = Darpionportrait;
                a.sprite = a1;
                b.sprite = none;
                break;
            case 2:
                portrait.sprite = BatDarwinPortrait;
                a.sprite = a2;
                b.sprite = none;
                break;
        }
	}
}
