using UnityEngine;
using System.Collections;

public class KirbyCode : MonoBehaviour {

	// Use this for initialization

    private bool reversed;
    private Vector2 localVel;
    private int jumpcount;
    private Sprite Avatar;
    private bool IsCrouched = false;
    public LayerMask layer;
    private bool iSGrounded;
    private bool isDashing;
    public float delay = 0.5f;
    public float dashed = 2.0f;
    private float _lastbuttonpress;
    private float _lastdash;
	void Start () 
    {
        localVel = GetComponent<Rigidbody2D>().velocity;
        Avatar = GetComponent<SpriteRenderer>().sprite;
        reversed = false;
        isDashing = false;
	}
	
	// Update is called once per frame
	void Update () 
    {

        if(GetComponent<BoxCollider2D>().IsTouchingLayers(layer))
        {
            iSGrounded = true;
            jumpcount = 0;
        }

        //WASD controls
	    if(Input.GetKeyDown(KeyCode.W))
        {
            //Jump
            if(jumpcount == 0 && iSGrounded)
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, 225.0f));
                //transform.Translate(new Vector3(0.0f, 0.5f, 0.0f));
                iSGrounded = false;
                jumpcount++;
            }
            else if (jumpcount <= 5 && !iSGrounded)
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, 125.0f));
                //transform.Translate(new Vector3(0.0f, 0.4f, 0.0f));
                jumpcount++;
                if(jumpcount == 5)
                {
                    //Avatar = sprite that puffs air;
                }
            }
            

            //EnterDoorWays
            //Application.LoadLevel("EnterLevelOrIDnum");
        }

	    if(Input.GetKey(KeyCode.A))
        {

            transform.Translate(new Vector3(-1.0f * Time.deltaTime, 0.0f, 0.0f));
            if (!reversed)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1.0f, transform.localScale.y, transform.localScale.z);
                reversed = true;
            }
        }
	    else if(Input.GetKey(KeyCode.S))
        {
            //GetComponent<SpriteRenderer>().sprite = crouching;
            
        }
	    else if(Input.GetKey(KeyCode.D))
        {
            
            if(isDashPossible && Input.GetKeyUp(KeyCode.D))
            {

            }
            else
            {
                //Avatar = walking
                transform.Translate(new Vector3(1.0f * Time.deltaTime, 0.0f, 0.0f));
                if (reversed)
                {
                    transform.localScale = new Vector3(transform.localScale.x * -1.0f, 0.0f, transform.localScale.z);
                    reversed = false;
                }
            }


        }
        

        //Action buttons
	    if(Input.GetKey(KeyCode.Space))
        {
            
        }

        //Extra Button
        //if(Input.GetKey(KeyCode.RightShift))
        //{

        //}
	}

    float VelLimit(float velocity)
    {
        velocity = velocity % 5.0f;
        return velocity;
    }

    bool isDashPossible
    {
        get
        {
            return Time.time - _lastdash > dashed;
        }
    }
}
