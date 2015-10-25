using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {

    private bool open;
	// Use this for initialization
	void Start () {
        open = false;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            open = true;
        }
    }


    void LoadNextLevel()
    {
        Debug.Log("EnteringLoad");
        if(Application.loadedLevelName == "Level1QuickTest")
            Application.LoadLevel("Level2QuickTest");
        else if(Application.loadedLevelName == "Level2QuickTest")
            Application.LoadLevel("Level3QuickTest");
        else if(Application.loadedLevelName == "Level3QuickTest")
            Application.LoadLevel("EvilTreeBoss");
    }
}
