using UnityEngine;
using System.Collections;
using Assets.Util;
using System.Collections.Generic;

public class Scarfy : MonoBehaviour {
    Animator animator;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
    }
	
    // Update is called once per frame
    void Update () {

    }

    void OnPlayerExitRange()
    {
        animator.SetBool("isAttacking", false);
    }

    void OnPlayerEnterRange()
    {
        animator.SetBool("isAttacking", true);
    }
}
