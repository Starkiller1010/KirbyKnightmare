using UnityEngine;
using System.Collections;
using Assets.Util;
using System.Collections.Generic;

public class Scarfy : MonoBehaviour {
    const float JUMP_INTERVAL = 2; // seconds
    const float TURN_INTERVAL = 8; // seconds
    Animator animator;
    Rigidbody2D body;
    Direction direction = Direction.RIGHT;
    RepeatedAction jumpAction;
    RepeatedAction turnAction;
    

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();


        jumpAction = new RepeatedAction(Jump, JUMP_INTERVAL, this);
        turnAction = new RepeatedAction(TurnAround, TURN_INTERVAL, this);

        jumpAction.Start();
        turnAction.Start();
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnPlayerEnterAttentionRange()
    {
        print("Player entered attention range");
    }

    void Attack()
    {
        animator.SetBool("isAttacking", true);
    }

    void Jump()
    {
        float x = direction == Direction.RIGHT ? 50.0f : -50.0f;
        body.AddForce(new Vector2(x, 100.0f));
    }

    void TurnAround()
    {
        if (direction == Direction.LEFT)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            direction = Direction.RIGHT;
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            direction = Direction.LEFT;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("Player entered attention range");
            animator.SetBool("isAttacking", true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            animator.SetBool("isAttacking", false);
        }
    }

    private enum Direction
    {
        LEFT,
        RIGHT
    }
}
