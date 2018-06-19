using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wolf : MonoBehaviour {

    public RuntimeAnimatorController walk;
    public RuntimeAnimatorController idel;
    public RuntimeAnimatorController hit;
    public RuntimeAnimatorController ready;
    public RuntimeAnimatorController jumpattack;

    public GameObject wdead;
    public GameObject Target;

    private float moveSpeed;
    private float cirleSpeed;

    public float invisible;
    public float live;

    private float state;

    private float attacktimer;
    private float attack;

    private float animationblock;

    private float movepattern = 1;
    private float actiontime;

    private float circle;
    private float doge;
	// Use this for initialization
	void Start () {
        Target = GameObject.Find("player (1)");
	}

    // Update is called once per frame
    void Update() {

        float distance = Vector3.Distance(Target.transform.position, transform.position);

        actiontime -= 1;


        if (animationblock == 0)
        {
            this.GetComponent<Animator>().runtimeAnimatorController = idel as RuntimeAnimatorController;
        }

        if (animationblock == 1)
        {
            this.GetComponent<Animator>().runtimeAnimatorController = walk as RuntimeAnimatorController;
        }


        //flip to look at player
        if (Target.transform.position.x < transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        if (Target.transform.position.x > transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }


        if (movepattern == 1)
        {

            transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, moveSpeed * Time.deltaTime);

        }

        ///chase

        if (GetComponentInParent<rudel>().chase == 1 && distance >= 5)
        {

            moveSpeed = Random.Range(4, 5.5f);
            animationblock = 1;
            movepattern = 1;
        }


        if (attack != 9)
        {

            ///intimidate
            if (distance <= 4 && distance >= 3 && actiontime <= 0)
            {
                cirleSpeed = Random.Range(1, 3);
                circle = 2;
                moveSpeed = Random.Range(-0.5f, -1.5f);

            }

            //ditermen cirle speed
            if (cirleSpeed == 1)
            {
                cirleSpeed = Random.Range(20, 30);
            }
            else
            if (cirleSpeed == 2)
            {
                cirleSpeed = Random.Range(-20, -30);
            }

            ///cirle
            if (circle == 2)
            {
                transform.RotateAround(Target.transform.position, new Vector3(0, 0, 10), cirleSpeed * Time.deltaTime);
            }


            ///keep distance
            if (distance <= 3 && distance >= 2 && movepattern != 4)
            {
                movepattern = 2;
                actiontime = 10;
            }

            if (movepattern == 2)
            {
                transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, (actiontime * -1) * Time.deltaTime);

                if (actiontime <= 0)
                {
                    movepattern = 1;
                }
            }
        }

        //rady attack
        attacktimer -= 1;

        if(distance <= 4 && attacktimer <= 0)
        {
            attack = Random.Range(1, 10);
            attacktimer = 40;
        }

        if (attack >= 9)
        {
            this.GetComponent<Animator>().runtimeAnimatorController = ready as RuntimeAnimatorController;

            GetComponentInChildren<BoxCollider2D>().enabled = true;

            moveSpeed = 0;

            if (distance >= 6)
            {
                attack = 0;
            }

            if (distance >= 3 && attack <=9)
            {
                transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, (0.8f * Time.deltaTime));
            }

            if (attacktimer <= 0)
            {
                release();
            }

            if (distance <= 3)
            {
                attack = 10;
            }

            if (attack >= 10)
            {
                transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, (20f * Time.deltaTime));
                this.GetComponent<Animator>().runtimeAnimatorController = jumpattack as RuntimeAnimatorController;
                release();
            }
        }
        else
        {
            GetComponentInChildren<BoxCollider2D>().enabled = false;
        }

        //get hit
        if (movepattern == 4)
        {
            attack = 0;
            moveSpeed = -1f;
            actiontime = 2000;
            this.GetComponent<Animator>().runtimeAnimatorController = hit as RuntimeAnimatorController;
            transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, (moveSpeed + (moveSpeed * 0.5f) * Time.deltaTime));

            if (invisible <= 0)
            {
                live -= 1;
                invisible = 1;
            }
        }
        else
        {
            invisible = 0;
        }

        if (live <= 0)
        {

            this.GetComponent<Animator>().runtimeAnimatorController = hit as RuntimeAnimatorController;
            this.GetComponent<Collider2D>().enabled = false;
            this.GetComponent<wdead>().enabled= true;
            this.GetComponent<footprint>().enabled = false;
            GetComponentInChildren<BoxCollider2D>().enabled = false;
            this.enabled = false;
        }
    }

    private void release()
    {
        ///release into walk,idel animation
        if (this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !this.GetComponent<Animator>().IsInTransition(0))
        {
            animationblock = 0;
            attack = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "sword")
        {
            movepattern = 4;
        }
    }
}
