using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	
	// Use this for initialization
	[SerializeField]
	GameObject Player;
	void Start () 
	{
		transform.position = new Vector3(Player.transform.position.x, transform.position.y, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position = new Vector3(Player.transform.position.x, transform.position.y, transform.position.z);
		
	}
}