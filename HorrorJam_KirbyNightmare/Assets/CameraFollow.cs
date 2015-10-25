using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	
	// Use this for initialization
	[SerializeField]
	GameObject Player;
	void Start () 
<<<<<<< HEAD
	{
		transform.position = new Vector3(Player.transform.position.x, transform.position.y, transform.position.z);
=======
    {
        transform.position = new Vector3(Player.transform.position.x + Camera.main.orthographicSize, transform.position.y, transform.position.z);
>>>>>>> refs/remotes/origin/Gerard
	}
	
	// Update is called once per frame
	void Update () 
<<<<<<< HEAD
	{
		transform.position = new Vector3(Player.transform.position.x, transform.position.y, transform.position.z);
		
	}
}
=======
    {
        transform.position = new Vector3(Player.transform.position.x, transform.position.y, transform.position.z);
	}

    void OnTriggerEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            transform.Translate(new Vector3(other.collider.transform.position.x, other.collider.transform.position.y, other.collider.transform.position.z));
        }
    }
}
>>>>>>> refs/remotes/origin/Gerard
