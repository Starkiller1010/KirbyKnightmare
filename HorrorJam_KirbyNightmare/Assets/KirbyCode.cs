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
    public LayerMask Groundlayer;
    private bool iSGrounded;
    private bool isDashing;
    public float delay = 0.5f;
    public float dashed = 2.0f;
    private float _lastbuttonpress;
    private float _lastdash;
    Animator anim;
    KirbyAction actions;
    KirbyActions message;

    public bool Grounded { get { return iSGrounded; } set { iSGrounded = value; } }


    //enum KirbyActions
    //{
    //    K_STAND,
    //    K_WALKLEFT,
    //    K_WALKRIGHT,
    //    K_DASH,
    //    K_JUMP,
    //    K_SUCK,
    //    K_BLOW,
    //    K_SPIT,
    //    K_CLIMB,
    //    K_COPY,
    //    K_ENTER_DOOR,
    //    K_ATTACK,
    //    K_CROUCH,
    //    K_SLIDE,
    //    K_FIRE,
    //    K_ICE,
    //    K_SPARK,
    //    K_BEAM,
    //    K_GET_HIT
    //}
	void Start () 
    {
        localVel = GetComponent<Rigidbody2D>().velocity;
        Avatar = GetComponent<SpriteRenderer>().sprite;
        reversed = false;
        isDashing = false;
        anim = GetComponent<Animator>();
        message = KirbyActions.K_IDLE;

	}

	
	// Update is called once per frame
	void Update () 
    {
       
        
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            healthcount--;
            //if(something is in mouth or has ability)
            //{ }
        }

        if (other.gameObject.tag == "Ground")
        {
            Debug.Log("Resetting jump");
            Grounded = true;
            jumpcount = 0;
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Door")
        {
            if(Input.GetKeyDown(KeyCode.W))
            {
               // message = KirbyActions.K_ENTER_DOOR;
                //Enter Door Animation

                //Application.LoadLevel("NextLevel");
            }
        }

        //if (message != null)
        //SendMessage("DoStuff", message);
    }
    

    void FixedUpdate()
    {

        //float move = Input.GetAxis("Horizontal");

        //anim.SetFloat("move", Mathf.Abs(move));

        //WASD controls
        if (Input.GetKeyDown(KeyCode.W))
        {
            message = KirbyActions.K_JUMP;
            //Jump
            if (jumpcount == 0 && Grounded)
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, 225.0f));
                //transform.Translate(new Vector3(0.0f, 0.5f, 0.0f));
                Grounded = false;
                jumpcount++;
            }
            else if (jumpcount <= 5 && !Grounded)
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, 125.0f));
                //transform.Translate(new Vector3(0.0f, 0.4f, 0.0f));
                jumpcount++;
                if (jumpcount == 5)
                {
                    //Animation sprite that puffs;
                }
            }

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
            if(Input.GetKeyDown(KeyCode.LeftShift))
            {
                transform.Translate(new Vector3(2.0f * Time.deltaTime, 0.0f, 0.0f));
                if (reversed)
                {
                    transform.localScale = new Vector3(transform.localScale.x * -1.0f, transform.localScale.y, transform.localScale.z);
                    reversed = false;
                }
            }
            else
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
            message = KirbyActions.K_IDLE;

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
   
         //SendMessage("DoStuff", message);
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
