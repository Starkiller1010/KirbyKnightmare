using UnityEngine;
using System.Collections;

public class EventsBox : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            other.SendMessage("EnemyJump", SendMessageOptions.DontRequireReceiver);
            print("EnemyJump");
        }
    }
}
