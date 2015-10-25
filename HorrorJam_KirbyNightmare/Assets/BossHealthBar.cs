using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BossHealthBar : MonoBehaviour {

	public Slider bossHealth;
	public Boss baws;
	private int health;

	// Use this for initialization
	void Start () {
		bossHealth = baws.healthcount;
	}
	
	// Update is called once per frame
	void Update () {
		if (health != baws.healthcount) {
			health = baws.healthcount;
			UpdateBossHealth ();
		}
	
	}

	void UpdateBossHealth() {
		if (health > 5)
			health = 5;
		if (health < 0)
			health = 0;
		bossHealth.value = (float)health/5;
		if(health == 0)
			bossHealth.fillRect.gameObject.SetActive (false);
		else
			bossHealth.fillRect.gameObject.SetActive (true);
	}
}
