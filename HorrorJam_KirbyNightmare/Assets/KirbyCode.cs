using UnityEngine;
using System.Collections;

public class KirbyCode : MonoBehaviour {

	// Use this for initialization

    private bool reversed = false;
    private Vector2 localVel;
    private int jumpcount = 7;
    private Sprite Avatar;
    private bool IsCrouched = false;
    Animator anim;

    void Start () 
    {
        localVel = GetComponent<Rigidbody2D>().velocity;
        Avatar = GetComponent<SpriteRenderer>().sprite;
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () 
    {
        //WASD controls
	    if(Input.GetKeyDown(KeyCode.W))
        {
            //Jump
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, 200.0f));
            

            //EnterDoorWays

        }

	    if(Input.GetKey(KeyCode.A))
        {

            transform.Translate(new Vector3(-1.0f * Time.deltaTime, 0.0f, 0.0f));
            if (!reversed)
            {
                transform.localScale.Set(transform.localScale.x * -1.0f, transform.localScale.y, transform.localScale.z);
                reversed = true;
            }
        }
	    else if(Input.GetKey(KeyCode.S))
        {
            //GetComponent<SpriteRenderer>().sprite = crouching;
            
        }
	    else if(Input.GetKey(KeyCode.D))
        {
            //if (localVel.x > -1.0f)
            //    localVel = new Vector2(0.0f, localVel.y);

            //if (localVel.x < 1.0f)
            //    GetComponent<Rigidbody2D>().AddForce(new Vector2(4.0f, 0.0f));
            //else
            //    localVel = new Vector2(localVel.x, localVel.y);
            transform.Translate(new Vector3(1.0f * Time.deltaTime, 0.0f, 0.0f));
        
            if (reversed)
            {
                transform.localScale.Set(transform.localScale.x * -1.0f, 0.0f, transform.localScale.z);
                reversed = false;
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

    void FixedUpdate()
    {

        float move = Input.GetAxis("Horizontal");

        anim.SetFloat("move", Mathf.Abs(move));
    }



}
