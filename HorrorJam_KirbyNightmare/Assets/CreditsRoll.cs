using UnityEngine;
using System.Collections;

public class CreditsRoll : MonoBehaviour {

	public TextAsset CreditsText;

	public float Speed = 0.1f;

	public int MaxFontSize = 20;

	public GUIStyle TextStyle = new GUIStyle();

	private GameObject creditHolder;

	private GUIText creditText;

	private Transform creditHolderTransform;

	public void Start()
	{
		InitializeCreditHolder ();
		RecalculateFontSize ();
		PlaceCreditsAtTheScreensBottom ();
	}

	public void Update()
	{
		RecalculateFontSize ();
		MoveCreditsTextUntilEndIsReached ();
	}

	void PlaceCreditsAtTheScreensBottom()
	{
		float screeny = 0;
		float y = 0.0f;
		float minScreenY = (-1.0f * creditText.GetScreenRect ().height) + Screen.height / 2;
		do
		{
			creditHolderTransform.position = new Vector2(0.5f, y);
			y -= 0.1f;

			screeny = creditText.GetScreenRect ().y;
		}
	}
}
