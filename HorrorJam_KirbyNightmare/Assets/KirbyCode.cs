using UnityEngine;
using System.Collections;


public enum KirbyStates
{
    //Exit Game : 0
    BYE,
    //Finish Stage : 1
    GOAL,
    //Death : 2
    MISS,
    //Damaged : 3
    OUCH,
    //Swallowed with no power gain : 4
    NOTHING,
    //Without Powers : 5
    NORMAL,
    //Swallowed with Fire gain : 6
    FIRE,
    //Swallowed with Beam gain : 7
    BEAM,
    //Swallowed with Spark gain : 8
    SPARK
}

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
    public Sprite Airpuff1;
    public Sprite Airpuff2;
    //Animator anim;
    KirbyAction actions;
    KirbyActions message;
    private bool isSliding;
    private bool MouthFull;
    public GameObject SuckZone;
    public bool inhaling;

    private float _lastbuttonpress;
    private float _taptime;
    private bool tapping;
    bool doubletap = false;
[Tooltip("KirbyStates enum displayed in UI picture")] 
    public KirbyStates currState;


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
        currState = KirbyStates.SPARK;

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

        if(healthcount == 0)
        {
            currState = KirbyStates.MISS;
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

    void dashleft()
    {
        while(Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-2.0f * Time.deltaTime, 0.0f, 0.0f));
        }
    }
    

    void FixedUpdate()
    {
        doubletap = false;

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
            

        }

        if (Input.GetKey(KeyCode.A)&& !IsCrouched && !GetComponent<Animator>().GetBool("isSucking"))
        {

            //if (Time.time < _taptime + 0.4f)
            //    doubletap = true;
            //else
            //    _taptime = Time.time;
            if (Grounded)
                GetComponent<Animator>().Play("WalkingCycle");
            if (Input.GetKey(KeyCode.LeftShift))
            {
                if (!reversed)
                {
                    transform.localScale = new Vector3(transform.localScale.x * -1.0f, transform.localScale.y, transform.localScale.z);
                    reversed = true;
                }
                transform.Translate(new Vector3(-2.0f * Time.deltaTime, 0.0f, 0.0f));
                //dashleft();
            }
            else
            {
                if (!reversed)
                {
                    transform.localScale = new Vector3(transform.localScale.x * -1.0f, transform.localScale.y, transform.localScale.z);
                    reversed = true;
                }
               //while (Input.GetKey(KeyCode.A))
                    transform.Translate(new Vector3(-1.0f * Time.deltaTime, 0.0f, 0.0f));
            }

            GetComponent<Animator>().SetBool("move", true);
<<<<<<< HEAD
=======
            if (GetComponent<BoxCollider2D>().IsTouching(GameObject.Find("Ground").GetComponent<BoxCollider2D>()))
                GetComponent<Animator>().Play("WalkingCycle");
            GetComponent<Animator>().SetBool("move", true);
>>>>>>> parent of 93fe8eb... Kirby Door enter works
            if(GetComponent<BoxCollider2D>().IsTouching(GameObject.Find("Ground").GetComponent<BoxCollider2D>()))
                GetComponent<Animator>().Play("WalkingCycle");

        }
        else if (Input.GetKey(KeyCode.S))
        {
            //GetComponent<SpriteRenderer>().sprite = crouching;
            IsCrouched = true;

        }
        else if (Input.GetKey(KeyCode.D) && !IsCrouched && !GetComponent<Animator>().GetBool("isSucking"))
        {
                if(Grounded)
                GetComponent<Animator>().Play("WalkingCycle");
            if (Input.GetKey(KeyCode.LeftShift))
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
<<<<<<< HEAD
            
=======
            if (GetComponent<BoxCollider2D>().IsTouching(GameObject.Find("Ground").GetComponent<BoxCollider2D>()))
                GetComponent<Animator>().Play("WalkingCycle");
>>>>>>> parent of 93fe8eb... Kirby Door enter works


        }
        else
        {
            GetComponent<Animator>().SetBool("move", false);
            //GetComponent<Animator>().SetBool("jumping", false);
            //message = KirbyActions.K_IDLE;
            if(Grounded == true && !GetComponent<Animator>().GetBool("isSucking"))
                GetComponent<Animator>().Play("Idle");
            IsCrouched = false;
            if (SuckZone.activeInHierarchy)
            {   
                SuckZone.SetActive(false);
                GetComponent<Animator>().SetBool("isSucking", false);
            }
        }

        //Action buttons
        if (Input.GetKey(KeyCode.Space))
        {
            //Sucking Code
            if (!SuckZone.activeInHierarchy)
            {
                SuckZone.SetActive(true);
                GetComponent<Animator>().SetBool("isSucking", true);
                SuckZone.GetComponent<ParticleSystem>().Play();
                //GetComponent<Animator>().Play("kirbySuck");
            }
            //If something in mouth
            if (MouthFull)
            {
                GetComponent<Animator>().SetBool("isSucking", false);
                SuckZone.SetActive(false);
            }
            //If player has an ability
            if(currState > KirbyStates.NORMAL)
            {
                //KirbyPowers.SendMessage("KirbyAbility", currState);
            }

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

<<<<<<< HEAD
=======
            //Sucking Code
            if(!SuckZone.enabled)
            SuckZone.enabled = true;
            //If something in mouth
            //if (MouthFull)
                
            //If player has an ability
>>>>>>> winston
        }

        //Extra Button
        if(Input.GetKey(KeyCode.RightShift))
        {
              //Release Ability
            currState = KirbyStates.NORMAL;
            
        }
   
         //SendMessage("DoStuff", message);
    }



    void EnemySuckedIn(GameObject enemy, int state)
     {
        MouthFull = true;
        enemy.SetActive(false);
        if(state > 5 && IsCrouched)
        {
            currState = (KirbyStates)state;
        }
     }

<<<<<<< HEAD
=======
    void Death()
    {
        //Remind Jesse about death
        Application.LoadLevel("GameOver");
    }
>>>>>>> parent of 93fe8eb... Kirby Door enter works
}
