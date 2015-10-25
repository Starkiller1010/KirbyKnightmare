using UnityEngine;
using System.Collections;

public enum KirbyActions
{
    K_STAND,
    K_WALKLEFT,
    K_WALKRIGHT,
    K_DASH,
    K_JUMP,
    K_SUCK,
    K_BLOW,
    K_SPIT,
    K_CLIMB,
    K_COPY,
    K_ENTER_DOOR,
    K_ATTACK,
    K_CROUCH,
    K_SLIDE,
    K_FIRE,
    K_ICE,
    K_SPARK,
    K_BEAM,
    K_GET_HIT,
    K_IDLE
}
public class KirbyAction : MonoBehaviour 
{
    GameObject party;
    public KirbyCode Player;
    public int jumpcount = 0;


	// Use this for initialization
	void Start () 
    {
        party = GameObject.Find("SuckZone");
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Player.GetComponent<BoxCollider2D>().IsTouchingLayers(Player.Groundlayer))
        {
            Player.Grounded = true;
            jumpcount = 0;
        }
	}

    void DoStuff(KirbyActions action)
    {
        Debug.Log("Entered Switch Method");
        switch (action)
        {
            case KirbyActions.K_STAND:
                {
                    break;
                }
            case KirbyActions.K_WALKLEFT:
                { 
                    break;
                }
            case KirbyActions.K_WALKRIGHT:
                { 
                    break; 
                }
            case KirbyActions.K_DASH:
                { 
                    break;
                }
            case KirbyActions.K_JUMP:
                {
                    //Jump
                    if (jumpcount == 0 && Player.Grounded)
                    {
                        GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, 225.0f));
                        //transform.Translate(new Vector3(0.0f, 0.5f, 0.0f));
                        Player.Grounded = false;
                        jumpcount++;
                    }
                    else if (jumpcount <= 5 && !Player.Grounded)
                    {
                        GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, 125.0f));
                        //transform.Translate(new Vector3(0.0f, 0.4f, 0.0f));
                        jumpcount++;
                        if (jumpcount == 5)
                        {
                            //Avatar = sprite that puffs air;
                        }
                    }
                    break; 
                }
            case KirbyActions.K_SUCK:
                {
                    GameObject Suck = GameObject.Find("SuckZone");
                    Suck.GetComponent<ParticleSystem>().Play();// SetActive(true);
                    break;
                }
            case KirbyActions.K_SPIT:
                {
                    break; 
                }
            case KirbyActions.K_CLIMB:
                { 
                    break;
                }
            case KirbyActions.K_COPY:
                {
                    break;
                }
            case KirbyActions.K_ENTER_DOOR:
                { 
                    //Animation enter door
                    //
                    
                    //Load Next Level
                    //Invoke(Application.LoadLevel("NextLevel"), Animation time);
                    break; 
                }
            case KirbyActions.K_ATTACK:
                { 
                    break;
                }
            case KirbyActions.K_CROUCH:
                { 
                    break;
                }
            case KirbyActions.K_SLIDE:
                { 
                    break;
                }
            case KirbyActions.K_FIRE:
                { 
                    break; 
                }
            case KirbyActions.K_SPARK:
                { 
                    break; 
                }
            case KirbyActions.K_BEAM:
                { 
                    break;
                }
            case KirbyActions.K_GET_HIT:
                { 
                    break; 
                }
            case KirbyActions.K_IDLE:
                { 
                    GameObject Suck = GameObject.Find("SuckZone");
                    if (Suck.activeSelf)
                        Suck.GetComponent<ParticleSystem>().Stop();// SetActive(true);

                        //Suck.SetActive(false);
                    break;
                }
        }
    }
}
