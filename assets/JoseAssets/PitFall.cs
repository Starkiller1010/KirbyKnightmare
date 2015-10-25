using UnityEngine;
using System.Collections;

public class PitFall : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<KirbyCode>().healthcount = 0;
            other.gameObject.SendMessage("Death");
        }
    }
}
