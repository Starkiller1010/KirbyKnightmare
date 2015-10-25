using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {

    public int healthcount;
    [SerializeField]
    GameObject Player;
    private float Delay = 5.5f;
    private float LastTime;
    private bool TreeSwitch = false;
    public float MapWidth = 200;
    private Animator animate;
    private enum APM { Intro, Idle, Spit, Watch, Switch };
    private APM curState;

	// Use this for initialization
	void Start () 
    {
        healthcount = 5;
        animate = GetComponent<Animator>();
        curState = APM.Intro;
        StartCoroutine("AnimationRunning");
        LastTime = Time.time;
	}
	
	// Update is called once per frame
    void Update()
    {
        if(LastTime + Delay > Time.time)
        {
            switch(curState)
            {
                
                case APM.Idle:
                    {
                        curState = APM.Spit;
                        break;
                    }
                case APM.Spit:
                    {
                        curState = APM.Watch;
                        break; 
                    }
                case APM.Watch:
                    {
                        curState = APM.Switch;
                        break; 
                    }
                case APM.Switch:
                    {
                        curState = APM.Idle;
                        break;
                    }
            }
            StartCoroutine("AnimationRunning");
            LastTime = Time.time;
        }
    }

    IEnumerator AnimationRunning()
    {
        switch (curState)
        {
            case APM.Intro:
                {
                    Player.GetComponent<KirbyCode>().Controllable = false;
                    animate.Play("EnterAnimation");
                    yield return new WaitForSeconds(5.0f);
                    Player.GetComponent<KirbyCode>().Controllable = true;
                    break; 
                }
            case APM.Idle:
                {
                    animate.Play("Idle");
                    break;
                }
            case APM.Spit:
                {
                    animate.Play("Spit");
                    break;
                }
            case APM.Watch:
                {
                    animate.Play("Attack");
                    break;
                }
            case APM.Switch:
                {
                    animate.Play("SwitchOut");
                    yield return new WaitForSeconds(2.0f);
                    animate.Play("SwitchIn");
                    break;
                }
            default:
                break;
        }
    }

    void Attack()
    {

    }

    void Switch(bool Side)
    {

    }
}
