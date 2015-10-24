using UnityEngine;
using System.Collections;

public class KirbyActionScript : MonoBehaviour {

    enum KirbyActions 
    { 
        K_STAND,
        K_WALK,
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
        K_GET_HIT
      }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void DoStuff(KirbyActions action)
    {
        switch (action)
        {
            case KirbyActions.K_STAND:
                break;
            case KirbyActions.K_WALK:
                break;
            case KirbyActions.K_DASH:
                break;
            case KirbyActions.K_JUMP:
                break;
            case KirbyActions.K_SUCK:
                break;
            case KirbyActions.K_SPIT:
                break;
            case KirbyActions.K_CLIMB:
                break;
            case KirbyActions.K_COPY:
                break;
            case KirbyActions.K_ENTER_DOOR:
                break;
            case KirbyActions.K_ATTACK:
                break;
            case KirbyActions.K_CROUCH:
                break;
            case KirbyActions.K_SLIDE:
                break;
            case KirbyActions.K_FIRE:
                break;
            case KirbyActions.K_SPARK:
                break;
            case KirbyActions.K_BEAM:
                break;
            case KirbyActions.K_GET_HIT:
                break;
            default:
                break;
        }
    }
}
