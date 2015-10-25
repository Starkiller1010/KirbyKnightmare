using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIHelpers : MonoBehaviour {

	public enum KirbyStates
	{
		BEAM,
		BYE,
		CLEAR,
		FIRE,
		GOAL,
		MISS,
		NORMAL,
		NOTHING,
		OUCH,
		SPARK
	}
	
	Slider kirbyHealth;
	Slider bossHealth;
	RawImage powerPicture;

	// Use this for initialization
	void Start () {
		kirbyHealth = GetComponent<Slider>();
		bossHealth = GetComponent<Slider>();
		powerPicture = GetComponent<RawImage> ();
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

	void UpdateBossHealth(int healthLeft) {
		if (healthLeft > 100)
			healthLeft = 100;
		if (healthLeft < 0)
			healthLeft = 0;
		bossHealth.value = (float)healthLeft/100;
	}

	void ChangePowerPicture(KirbyStates state) {
		Texture newTexture = null;
		switch (state) 
		{
			case KirbyStates.BEAM:
				newTexture = Resources.Load ("beam") as Texture;
				break;
			case KirbyStates.BYE:
				newTexture = Resources.Load ("bye") as Texture;
				break;
			case KirbyStates.CLEAR:
				newTexture = Resources.Load ("clear") as Texture;
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
