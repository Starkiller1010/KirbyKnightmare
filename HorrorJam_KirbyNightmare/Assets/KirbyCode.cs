using UnityEngine;
using System.Collections;

public class KirbyCode : MonoBehaviour {

	// Use this for initialization

    public int healthcount = 6;
    public int lives = 4;
    private bool reversed;
    private Rigidbody2D localVel;
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
    public Sprite Airpuff1;
    public Sprite Airpuff2;
    //Animator anim;
    KirbyAction actions;
    KirbyActions message;
    private bool isSliding;
    private bool MouthFull;
    public BoxCollider2D SuckZone;
    public bool inhaling;


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
        localVel = GetComponent<Rigidbody2D>();
        Avatar = GetComponent<SpriteRenderer>().sprite;
        reversed = false;
        isDashing = false;
        //anim = GetComponent<Animator>();
       // message = KirbyActions.K_IDLE;

	}

	
	// Update is called once per frame
	void Update () 
    {
           if(GetComponent<Animator>().GetBool("jumping") && GetComponent<Animator>().GetInteger("jumpCount") > 0)
           {
               GetComponent<Animator>().Play("kirbyjump");
           }

        if(isSliding && localVel.velocity.x == 0.0f)
        {
            isSliding = false;
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

        if (other.gameObject.tag == "Ground")
        {
            Debug.Log("Resetting jump");
            CancelInvoke();
            Grounded = true;
            if(GetComponent<Animator>().GetBool("jumping"))
            {
                GetComponent<Animator>().SetBool("jumping", false);
                GetComponent<Animator>().Play("Idle");

            }
        }
        if (inhaling)
        {
            EnemySuckedIn(other.gameObject);
            MouthFull = true;
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ground")
         jumpcount = 0;

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

    void JumpDelay()
    {
        //Avatar = Airpuff2;
        GetComponent<Animator>().SetBool("jumping", true);


    }
    

    void FixedUpdate()
    {

        //float move = Input.GetAxis("Horizontal");

        //anim.SetFloat("move", Mathf.Abs(move));

        //WASD controls
        if (Input.GetKeyDown(KeyCode.W))
        {
            //message = KirbyActions.K_JUMP;
            //Jump
            if (jumpcount == 0 && Grounded)
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, 225.0f));
                //transform.Translate(new Vector3(0.0f, 0.5f, 0.0f));
                Grounded = false;
                //GetComponent<Animator>().SetBool("jumping", true);
                jumpcount++;
                //Avatar = Airpuff1;
            }
            else if (jumpcount <= 5 && !Grounded)
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, 125.0f));
                //transform.Translate(new Vector3(0.0f, 0.4f, 0.0f));
                jumpcount++;
                GetComponent<Animator>().SetInteger("jumpCount", jumpcount);
                if (jumpcount == 5)
                {
                    //Animation sprite that puffs;
                    //Avatar = Airpuff1;
                    //Invoke("JumpDelay", 0.0f);
                }
                GetComponent<Animator>().SetBool("jumping", true);
            }
            else
            {
                //Lets out air and falls
            }
            Debug.Log("jumCount = ", gameObject);

        }

        if (Input.GetKey(KeyCode.A)&& !IsCrouched)
        {

            transform.Translate(new Vector3(-1.0f * Time.deltaTime, 0.0f, 0.0f));
            if (!reversed)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1.0f, transform.localScale.y, transform.localScale.z);
                reversed = true;
            }
            GetComponent<Animator>().SetBool("move", true);
            if(GetComponent<BoxCollider2D>().IsTouching(GameObject.Find("Ground").GetComponent<BoxCollider2D>()))
                GetComponent<Animator>().Play("WalkingCycle");

        }
        else if (Input.GetKey(KeyCode.S))
        {
            //GetComponent<SpriteRenderer>().sprite = crouching;
            IsCrouched = true;

        }
        else if (Input.GetKey(KeyCode.D) && !IsCrouched)
        {
            if(Input.GetKey(KeyCode.LeftShift))
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
            if (GetComponent<BoxCollider2D>().IsTouching(GameObject.Find("Ground").GetComponent<BoxCollider2D>()))
                GetComponent<Animator>().Play("WalkingCycle");


        }
        else
        {
            GetComponent<Animator>().SetBool("move", false);
            //GetComponent<Animator>().SetBool("jumping", false);
            //message = KirbyActions.K_IDLE;
            if(Grounded == true)
                GetComponent<Animator>().Play("Idle");
            IsCrouched = false;
        }

        //Action buttons
        if (Input.GetKey(KeyCode.Space))
        {
            if(IsCrouched && Input.GetKey(KeyCode.D) && !isSliding)
            {
                isSliding = true;
                localVel.AddForce(new Vector2(200.0f, 0.0f));
                //transform.Translate(new Vector3(2.0f, 0.0f, 0.0f));
                //GetComponent<Animator>().SetBool("StringSlide", true);
                if (reversed)
                {
                    transform.localScale = new Vector3(transform.localScale.x * -1.0f, transform.localScale.y, transform.localScale.z);
                    reversed = false;
                }
            }
            else if (IsCrouched && Input.GetKey(KeyCode.A) && !isSliding)
            {
                isSliding = true;
                localVel.AddForce(new Vector2(-200.0f, 0.0f));
                //transform.Translate(new Vector3(-2.0f, 0.0f, 0.0f));
                //GetComponent<Animator>().SetBool("StringSlide", true);
                if (!reversed)
                {
                    transform.localScale = new Vector3(transform.localScale.x * -1.0f, transform.localScale.y, transform.localScale.z);
                    reversed = true;
                }
            }

            //Sucking Code
            if(!SuckZone.enabled)
            SuckZone.enabled = true;
            //If something in mouth
            if (MouthFull)
                
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

    void EnemySuckedIn(GameObject enemy)
     {
        if(enemy.transform.FindChild("WEAPON"))
        {

        }
     }

}
