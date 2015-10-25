using UnityEngine;
using System.Collections;

public class Fading : MonoBehaviour {

    public Texture2D FadeOut;
    public float FadeTime;
    private int drawdepth = -1000;
    private float alpha = 1.0f;
    private int fadeDir = -1;

    void OnGUI()
    {
        alpha += fadeDir * FadeTime * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawdepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), FadeOut);
    }

    public float BeginFade(int direction)
    {
        fadeDir = direction;
        return (FadeTime);
    }

    void OnLevelWasLoaded()
    {
        BeginFade(-1);
    }
}
