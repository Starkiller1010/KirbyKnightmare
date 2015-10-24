using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    protected Rigidbody2D myRigibody;
    public float speed = 4;
    
    // Use this for initialization

    void Start () {
        



    }

    protected void iniThis() {
        myRigibody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update () {
	
	}

    protected void Move() {
        myRigibody.AddForce(new Vector2(speed, 0));
    }

    protected void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.tag == "Player")
        {
            SendMessage("Attack");
        }

        if (coll.collider.tag == "Block")
        {
            speed *= -1;
        }
    }

}
