using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class KirbyHealthBar : MonoBehaviour {

	public Slider kirbyHealth;
	public KirbyCode player;
	private int lastHealth = 6;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (lastHealth != player.healthcount) {
			lastHealth = player.healthcount;
			UpdateKirbyHealth ();
		}
	}

	void UpdateKirbyHealth() {
		if (player.healthcount > 6)
			player.healthcount = 6;
		if (player.healthcount < 0)
			player.healthcount = 0;
		switch(player.healthcount){
		case 0:
			kirbyHealth.value = -1;
			kirbyHealth.fillRect.gameObject.SetActive (false);
			break;
		case 1:
			kirbyHealth.value = (float)0.13;
			kirbyHealth.fillRect.gameObject.SetActive (true);
			break;
		case 2:
			kirbyHealth.value = (float)0.31;
			kirbyHealth.fillRect.gameObject.SetActive (true);
			break;
		case 3:
			kirbyHealth.value = (float)0.49;
			kirbyHealth.fillRect.gameObject.SetActive (true);
			break;
		case 4:
			kirbyHealth.value = (float)0.66;
			kirbyHealth.fillRect.gameObject.SetActive (true);
			break;
		case 5:
			kirbyHealth.value = (float)0.83;
			kirbyHealth.fillRect.gameObject.SetActive (true);
			break;
		case 6:
			kirbyHealth.value = 1;
			kirbyHealth.fillRect.gameObject.SetActive (true);
			break;

		}
	}
}
