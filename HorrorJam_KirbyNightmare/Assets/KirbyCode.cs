using UnityEngine;
using System.Collections;

public class KirbyCode : MonoBehaviour {

	// Use this for initialization

    public int healthcount = 6;
    public int lives = 4;
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
    Animator anim;
	void Start () 
    {
        localVel = GetComponent<Rigidbody2D>().velocity;
        Avatar = GetComponent<SpriteRenderer>().sprite;
        reversed = false;
        isDashing = false;
        anim = GetComponent<Animator>();

	}

	
	// Update is called once per frame
	void Update () 
    {

        if(GetComponent<BoxCollider2D>().IsTouchingLayers(layer))
        {
            iSGrounded = true;
            jumpcount = 0;
        }

        
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            healthcount--;
            //if(something is in mouth or has ability)
            //{ }
        }
    }
    

    void FixedUpdate()
    {

        //float move = Input.GetAxis("Horizontal");

        //anim.SetFloat("move", Mathf.Abs(move));

        //WASD controls
        if (Input.GetKeyDown(KeyCode.W))
        {
            //Jump
            if (jumpcount == 0 && iSGrounded)
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
                if (jumpcount == 5)
                {
                    //Avatar = sprite that puffs air;
                }
            }


            //EnterDoorWays
            //Application.LoadLevel("EnterLevelOrIDnum");
        }

        if (Input.GetKey(KeyCode.A))
        {

            transform.Translate(new Vector3(-1.0f * Time.deltaTime, 0.0f, 0.0f));
            if (!reversed)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1.0f, transform.localScale.y, transform.localScale.z);
                reversed = true;
            }
            GetComponent<Animator>().SetBool("move", true);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            //GetComponent<SpriteRenderer>().sprite = crouching;

        }
        else if (Input.GetKey(KeyCode.D))
        {
            
            {
                //Avatar = walking
                transform.Translate(new Vector3(1.0f * Time.deltaTime, 0.0f, 0.0f));
                if (reversed)
                {
                    transform.localScale = new Vector3(transform.localScale.x * -1.0f, transform.localScale.y, transform.localScale.z);
                    reversed = false;
                }
            }
            GetComponent<Animator>().SetBool("move", true);


        }
        else
        {
            GetComponent<Animator>().SetBool("move", false);
        }

        //Action buttons
        if (Input.GetKey(KeyCode.Space))
        {
            if(IsCrouched && Input.GetKey(KeyCode.D))
            {
                transform.Translate(new Vector3(4.0f, 0.0f, 0.0f));
                //GetComponent<Animator>().SetBool("StringSlide", true);
            }
            else if (IsCrouched && Input.GetKey(KeyCode.A))
            {
                transform.Translate(new Vector3(-4.0f, 0.0f, 0.0f));
                //GetComponent<Animator>().SetBool("StringSlide", true);
            }

            //Sucking Code

            //If something in mouth

            //If player has an ability
        }

        //Extra Button
        //if(Input.GetKey(KeyCode.RightShift))
        //{
              //Release Ability
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

     void DoDash()
    {
        Debug.Log("In DoDash()");
        _lastdash = Time.time;
        transform.Translate(4.0f * Time.deltaTime, 0.0f, 0.0f);
    }

}
