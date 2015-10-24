using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    protected Rigidbody2D myRigibody;
    public float speed = 4;
    public float jumpHigh = 280;
    public bool canJump = true;
    protected float randomTimeToJump = 2;
    public float MaxJumpTime = 5;
    public float MinJumpTime = 3;
    protected float timeToAvoidTurn = 0;
    protected bool canMove = true;
    protected bool isGetToEat = false;
    protected GameObject player;
    public int weapontype = 0;


    // Use this for initialization

    void Start () {
        



    }

    protected void iniThis() {
        myRigibody = GetComponent<Rigidbody2D>();
        randomTimeToJump = Random.Range(1.0f, 3.0f);
        player = GameObject.FindGameObjectWithTag("Player") as GameObject;
    }

    protected void RandomTimeToJump()
    {
        randomTimeToJump = Random.Range(MinJumpTime, MaxJumpTime);
    }

    // Update is called once per frame
    void Update () {
	
	}

    protected void Move() {
        //myRigibody.AddForce(new Vector2(speed, 0));
        transform.Translate(new Vector3(speed, 0, 0)*Time.deltaTime);
    }
    
    protected void EnemyJump() {
        if(canJump)
        {
            myRigibody.AddForce(Vector3.up * jumpHigh);
        }
            
    }

    protected void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.collider.tag == "Underground")
        {
            canJump = true;
            //GetComponent<Animator>().SetBool("jump", false);
            //GetComponent<Animator>().SetBool("walking", true);
        }

       
    }
    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Vacuum")
        {
            
            isGetToEat = true;
            canMove = false;
            gameObject.SendMessage("StopShowWeapon");
        }
    }
    /**
    protected void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Vacuum")
        {
            isGetToEat = false;
            canMove = true;
            GetComponent<Animator>().enabled = true;
        }
        print("xxx212");
    }**/
    
    protected void OnCollisionEnter2D(Collision2D coll)
    {
     
        if (coll.collider.tag == "Player")
        {
            SendMessage("Attack",SendMessageOptions.DontRequireReceiver);
            Death();
        }
    }

    protected void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.transform.tag == "Underground")
        {
            canJump = false;
            //GetComponent<Animator>().SetBool("jump", true);
        }
    }

    protected void TurnRound()
    {
        if(timeToAvoidTurn<Time.time)
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, 180, 0));
        timeToAvoidTurn = Time.time + 0.5f;
    }

    protected void Death()
    {
        
    }


}
