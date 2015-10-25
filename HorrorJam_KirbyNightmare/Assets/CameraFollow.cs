using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	// Use this for initialization
    [SerializeField]
    GameObject Player = null;
	void Start () 
    {
        if(Player!=null)
        transform.position = new Vector3(Player.transform.position.x + Camera.main.orthographicSize, transform.position.y, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Player != null)
        transform.position = new Vector3(Player.transform.position.x, transform.position.y, transform.position.z);
	}

    //void OnTriggerEnter2D(Collision2D other)
    //{
    //    if(other.gameObject.tag == "Player")
    //    {
    //        transform.Translate(new Vector3(other.collider.transform.position.x, other.collider.transform.position.y, other.collider.transform.position.z));
    //    }
    //}
}
