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
	
	}

	void AbilitySwitch() {
	}
}
