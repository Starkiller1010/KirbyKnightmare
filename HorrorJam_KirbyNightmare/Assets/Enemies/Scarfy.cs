using UnityEngine;
using System.Collections;

public class Scarfy : MonoBehaviour {

    Animator animator;
    Rigidbody2D body;
    float dt;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        //animator.Play("Idle");
        dt += Time.deltaTime;

        if (dt > 2)
        {
            //animator.Play("BounceRight");
            Debug.Log("Scarfy jumping...");
            body.AddForce(new Vector2(100.0f, 225.0f));
            dt = 0;
        }
	}
}
