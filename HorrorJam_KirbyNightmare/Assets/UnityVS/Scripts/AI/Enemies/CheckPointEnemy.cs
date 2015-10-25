using UnityEngine;
using System.Collections;

public class CheckPointEnemy : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.transform.tag == "Underground")
        {
            transform.parent.SendMessage("TurnRound");
        }
    }
}
