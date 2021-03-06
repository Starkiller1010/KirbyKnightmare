﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class KirbyStatePicture : MonoBehaviour {

	public RawImage powerPicture;
	public KirbyCode Player;
	private KirbyStates test;

	// Use this for initialization
	void Start () 
	{
		ChangePowerPicture ();
		test = Player.currState;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (test != Player.currState) {
			ChangePowerPicture();
			test = Player.currState;
		}
	}

	void ChangePowerPicture() {
		Texture newTexture = null;
		switch (Player.currState) 
		{
		case KirbyStates.BEAM:
			newTexture = Resources.Load ("beam") as Texture;
			break;
		case KirbyStates.BYE:
			newTexture = Resources.Load ("bye") as Texture;
			break;
		case KirbyStates.FIRE:
			newTexture = Resources.Load ("fire") as Texture;
			break;
		case KirbyStates.GOAL:
			newTexture = Resources.Load ("goal") as Texture;
			break;
		case KirbyStates.MISS:
			newTexture = Resources.Load ("miss") as Texture;
			break;
		case KirbyStates.NORMAL:
			newTexture = Resources.Load ("normal") as Texture;
			break;
		case KirbyStates.NOTHING:
			newTexture = Resources.Load ("nothing") as Texture;
			break;
		case KirbyStates.OUCH:
			newTexture = Resources.Load ("ouch") as Texture;
			break;
		case KirbyStates.SPARK:
			newTexture = Resources.Load ("spark") as Texture;
			break;
		default:
			newTexture = Resources.Load ("normal") as Texture;
			break;
		}
		powerPicture.texture = newTexture;
	}
}
