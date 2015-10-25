using UnityEngine;
using System.Collections;

public class KirbyPowers : MonoBehaviour {

	public KirbyCode Player;
	public KirbyStates ability;

	// Use this for initialization
	void Start () {
		ability = Player.currState;
	}
	
	// Update is called once per frame
	void Update () {
		if (ability != Player.currState) {
			ability = Player.currState;
			AbilitySwitch();
		}
	}

	void AbilitySwitch() {
		switch (ability) {
			case KirbyStates.SPARK:
			CircleCollider2D sparks = Player.gameObject.AddComponent<CircleCollider2D>();
			sparks.radius = 5;
			break;

		}
	}
}
