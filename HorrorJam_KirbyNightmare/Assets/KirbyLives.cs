﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class KirbyLives : MonoBehaviour {

	public Text lifeLine;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void UpdateLives(int lives) {
		lifeLine.text = "x" + lives.ToString ().PadLeft (2, '0');
	}
}
