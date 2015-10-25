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
				GetComponent<Animator>().Play("Eelectrified");
				Collider2D sparks = Player.gameObject.AddComponent<Collider2D>();
				Destroy (sparks);
				break;
			case KirbyStates.BEAM:
				GetComponent<Animator>().Play("Burn");
				Collider2D beam = Player.gameObject.AddComponent<Collider2D>();
				Destroy (beam);
				break;
			default:
				break;
		}
	}
}
