using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BossHealthBar : MonoBehaviour {

	public Slider bossHealth;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void UpdateBossHealth(int healthLeft) {
		if (healthLeft > 100)
			healthLeft = 100;
		if (healthLeft < 0)
			healthLeft = 0;
		bossHealth.value = (float)healthLeft/100;
	}
}
