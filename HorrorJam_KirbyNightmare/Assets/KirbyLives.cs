using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class KirbyLives : MonoBehaviour {

	public Text lifeLine;
	public KirbyCode Player;
	private int lives;
	// Use this for initialization
	void Start () {
		lives = Player.lives;
	}
	
	// Update is called once per frame
	void Update () {
		if (lives != Player.lives) {
			lives = Player.lives;
			UpdateLives ();
		}
	}

	void UpdateLives() {
		lifeLine.text = "x" + lives.ToString ().PadLeft (2, '0');
	}
}
