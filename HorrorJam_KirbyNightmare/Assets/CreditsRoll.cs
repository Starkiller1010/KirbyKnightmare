using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CreditsRoll : MonoBehaviour {

	public TextAsset CreditsText;

	public float Speed = 1.0f;

	public int MaxFontSize = 20;

	private GUIStyle TextStyle = new GUIStyle();

	private GameObject creditHolder;

	private GUIText creditText;

	private Transform creditHolderTransform;

	public GUIStyle Font;

	public void Start()
	{
		InitializeCreditHolder ();
		RecalculateFontSize ();
		PlaceCreditsAtTheScreensBottom ();
		TextStyle.font = Font.font;
	}

	public void Update()
	{
		RecalculateFontSize ();
		MoveCreditsTextUntilEndIsReached ();
	}

	private void InitializeCreditHolder()
	{
		creditHolder = new GameObject ("Credits");
		creditText = creditHolder.AddComponent<GUIText> ();
		creditText.alignment = TextAlignment.Center;
		creditText.anchor = TextAnchor.LowerCenter;
		creditText.text = GetCreditsText ();
		creditText.fontStyle = TextStyle.fontStyle;
		creditText.font = TextStyle.font;
		creditHolderTransform = creditHolder.transform;
	}

	void RecalculateFontSize()
	{
		int fontSize = MaxFontSize;
		do {
			creditText.fontSize = fontSize;
			fontSize--;
		} while(creditText.GetScreenRect ().width>Screen.width);
	}

	void PlaceCreditsAtTheScreensBottom()
	{
		float screeny = 0;
		float y = 0.0f;
		float minScreenY = (-1.75f * creditText.GetScreenRect ().height) + Screen.height / 2;
		do {
			creditHolderTransform.position = new Vector2 (0.5f, y);
			y -= 0.1f;

			screeny = creditText.GetScreenRect ().y;
		} while(screeny>minScreenY);
	}

	private string GetCreditsText()
	{
		if (CreditsText != null) {
			return CreditsText.text;
		}
		return CreatePlaceHolderText ();
	}

	private string CreatePlaceHolderText()
	{
		string placeHolderText = "TEAM KIRBY'S KNIGHTMARE\n\n\nPRODUCER:\t\tJESS BRUMMER\n\n LEAD ARTIST:\t\tJOSE MARRERO\n\nLEAD PROGRAMMER:\t\tGERARD VEGA\n\nPROGRAMMER:\t\tYANGJIE YAO\n\nPROGRAMMER:\t\tWINSTON TODD\n\nPROGRAMMER:\t\tTHADDEUS LATSA\n\nSOUND DESIGNER:\t\tJOHANN SANCHEZ\n\nPROGRAMMER:\t\tWESLY GORIS\n\nARTIST:\t\tMIKE BIANCHINI\n\nGAME OVER SCREEN ART:\t\tJOSH MIRMAN\n\nSPECIAL THANKS\nNINTENDO\nHAL LABRATORY";
		return placeHolderText;
	}

	private void MoveCreditsTextUntilEndIsReached()
	{
		if (creditText.GetScreenRect ().y > Screen.height * 0.35) {
			return;
		}
		creditHolderTransform.Translate (Vector3.up * Time.deltaTime * Speed * 5);
	}
}
