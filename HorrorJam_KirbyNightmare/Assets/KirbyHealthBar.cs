using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class KirbyHealthBar : MonoBehaviour {

	Slider kirbyHealth;

	// Use this for initialization
	void Start () {
		kirbyHealth = GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void UpdateKirbyHealth(int healthLeft) {
		if (healthLeft > 6)
			healthLeft = 6;
		if (healthLeft < 0)
			healthLeft = 0;
		kirbyHealth.value = (float)healthLeft/6;
	}
}
