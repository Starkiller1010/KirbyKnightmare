using UnityEngine;
using System.Collections;

public class WaddleDoo : Enemy {

    // Use this for initialization
    public Transform[] weapon;
    public Sprite w;
    float step = 0;
    GameObject sucking;
    void Start () {
        iniThis();
        //Fight();
        StartCoroutine(GoToJump());
        sucking = GameObject.FindGameObjectWithTag("Vacuum") as GameObject;
    }
	
	// Update is called once per frame
	void Update () {
        if(canMove&& !isGetToEat)
            Move();
        else if(isGetToEat)
        {
            if (sucking.active == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step += Time.deltaTime/2);
                if (Mathf.Abs(Mathf.Abs(transform.position.x) - Mathf.Abs(player.transform.position.x)) < 0.2f)
                {
                    player.SendMessage("EnemySuckedIn", weapontype, SendMessageOptions.DontRequireReceiver);
                    GetComponent<Animator>().enabled = false;
                }
            }
            else
            {
                canMove = true;
                isGetToEat = false;
                GetComponent<Animator>().enabled = true;
                step = 0;
            }
            
        }
    }

    void Fight()
    {
        if(!isGetToEat)
            StartCoroutine(ShowWeapons());
    }

    IEnumerator ShowWeapons()
    {
        GetComponent<Animator>().enabled = false;
        canMove = false;
        GetComponent<SpriteRenderer>().sprite = w;
        weapon[0].transform.gameObject.SetActive(false);
        weapon[1].transform.gameObject.SetActive(false);
        weapon[2].transform.gameObject.SetActive(false);
        weapon[3].transform.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        weapon[0].transform.gameObject.SetActive(false);
        weapon[1].transform.gameObject.SetActive(false);
        weapon[2].transform.gameObject.SetActive(true);
        weapon[3].transform.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        weapon[0].transform.gameObject.SetActive(false);
        weapon[1].transform.gameObject.SetActive(true);
        weapon[2].transform.gameObject.SetActive(false);
        weapon[3].transform.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        weapon[0].transform.gameObject.SetActive(true);
        weapon[1].transform.gameObject.SetActive(false);
        weapon[2].transform.gameObject.SetActive(false);
        weapon[3].transform.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        weapon[0].transform.gameObject.SetActive(false);
        weapon[1].transform.gameObject.SetActive(false);
        weapon[2].transform.gameObject.SetActive(false);
        weapon[3].transform.gameObject.SetActive(false);
        canMove = true;
        GetComponent<Animator>().enabled = true;
    }
    void StopShowWeapon()
    {
        StopCoroutine(ShowWeapons());
        weapon[0].transform.gameObject.SetActive(false);
        weapon[1].transform.gameObject.SetActive(false);
        weapon[2].transform.gameObject.SetActive(false);
        weapon[3].transform.gameObject.SetActive(false);
        canMove = false;
        
    }

    IEnumerator GoToJump() {
        int i;
        while (true)
        {
            yield return new WaitForSeconds(randomTimeToJump);
            i = Random.Range(0, 2);
            print(i);
            if(!isGetToEat)
            {

                if (i == 0)
                {

                    EnemyJump();
                }
                else
                {
                    Fight();
                }
                RandomTimeToJump();
            }
            else
            {
                GetComponent<Animator>().enabled = false;
            }
        }
    }

}
