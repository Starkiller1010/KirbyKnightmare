using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {

    public int healthcount;
    [SerializeField]
    GameObject Player;
    private float AttackDelay = 5.5f;
    private float LastAttTime;
    private bool TreeSwitch = false;
    public float MapWidth = 200;

	// Use this for initialization
	void Start () 
    {
        healthcount = 5;
	}
	
	// Update is called once per frame
    void Update()
    {

    }

    void AnimationRunning()
    {

    }

    void Attack()
    {

    }

    void Switch(bool Side)
    {

    }
}
