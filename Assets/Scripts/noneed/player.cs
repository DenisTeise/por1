using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

    public RuntimeAnimatorController doge;
    public RuntimeAnimatorController block;
    public RuntimeAnimatorController drawsword;
    public RuntimeAnimatorController attack1;
    public RuntimeAnimatorController attack2;
    public RuntimeAnimatorController attack3;
    public RuntimeAnimatorController walk;
    public RuntimeAnimatorController run;
    public RuntimeAnimatorController swordrun;
    public RuntimeAnimatorController idelsword;
    public RuntimeAnimatorController idelstand;

    private float animationblock;
    private float combo;
    private float firsthitcooldown;
    private float fightstate = 0;
    private float dogecooldown;

    public GameObject Target;

    public float moveSpeed;
    private float attackslide;
    // Use this for initialization
    void Start (){

    }
	
	// Update is called once per frame
	void Update () {
        ///look at the crouser
        if(Target.transform.position.x < transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0,180,0);
        }

        if (Target.transform.position.x > transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

    #region non fight idel
        ///switch between stop,walk,run
        if (animationblock == 0 && fightstate == 0)
        {
            if(Target.GetComponent<crouser>().Walkstate == 0)
            {
                moveSpeed = 0;
                this.GetComponent<Animator>().runtimeAnimatorController = idelstand as RuntimeAnimatorController;
            }

            if (Target.GetComponent<crouser>().Walkstate == 1)
            {
                moveSpeed = 2;
                this.GetComponent<Animator>().runtimeAnimatorController = walk as RuntimeAnimatorController;
            }

            if (Target.GetComponent<crouser>().Walkstate == 2)
            {
                moveSpeed = 4;
                this.GetComponent<Animator>().runtimeAnimatorController = run as RuntimeAnimatorController;
            }

            transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, moveSpeed * Time.deltaTime);
        }
    #endregion

    #region fight idel

        if (animationblock == 0 && fightstate == 1)
        {
            if (Target.GetComponent<crouser>().Walkstate == 0)
            {
                moveSpeed = 0;
                this.GetComponent<Animator>().runtimeAnimatorController = idelsword as RuntimeAnimatorController;
            }

            if (Target.GetComponent<crouser>().Walkstate == 2)
            {
                moveSpeed = 6;
                this.GetComponent<Animator>().runtimeAnimatorController = swordrun as RuntimeAnimatorController;
            }

            transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, moveSpeed * Time.deltaTime);
        }
        #endregion

        dogecooldown -= 1;

        ///doge
        if (Input.GetKeyDown("space") && fightstate == 1 && dogecooldown <= 0)
        {
            this.GetComponent<Animator>().runtimeAnimatorController = doge as RuntimeAnimatorController;
            animationblock = 6;
            attackslide = 30;
            dogecooldown = 40;
        }
        if (animationblock == 6)
        {
            attackslide -= 1f;
            transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, attackslide * Time.deltaTime);
        }

        ///drawweapon
        if (Input.GetMouseButtonDown(0) && fightstate == 0)
        {
            this.GetComponent<Animator>().runtimeAnimatorController = drawsword as RuntimeAnimatorController;
            animationblock = 4;
            fightstate = 1;
        }

    #region attacks
        if (fightstate == 1)
        {
            ///konter
            if(animationblock==0 && Input.GetMouseButtonDown(1))
            {
                animationblock = 5;
                this.GetComponent<Animator>().runtimeAnimatorController = block as RuntimeAnimatorController;
            }

            ///attack3
            if (animationblock == 2 && Input.GetMouseButtonDown(0))
            {
                combo = 2;
            }

            ///attack2
            if (animationblock == 1 && Input.GetMouseButtonDown(0))
            {
                combo = 1;
            }

            firsthitcooldown -= 1;

            ///attack1
            if (Input.GetMouseButtonDown(0) && animationblock <= 0 && firsthitcooldown <= 0)
            {
                this.GetComponent<Animator>().runtimeAnimatorController = attack1 as RuntimeAnimatorController;
                animationblock = 1;
                attackslide = 10;
                firsthitcooldown = 40;
            }
            //move wihle attack
            if (animationblock == 1)
            {
                attackslide -= 0.5f;
                transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, attackslide * Time.deltaTime);
            }

            ///attack2
            if (combo == 1 && this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !this.GetComponent<Animator>().IsInTransition(0))
            {
                this.GetComponent<Animator>().runtimeAnimatorController = attack2 as RuntimeAnimatorController;
                animationblock = 2;
                combo = 0;
                attackslide = 10;
            }
            else
            {
                release();
            }
            if (animationblock == 2)
            {
                attackslide -= 0.5f;
                transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, attackslide * Time.deltaTime);
            }

            ///attack3
            if (combo == 2 && this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !this.GetComponent<Animator>().IsInTransition(0))
            {
                this.GetComponent<Animator>().runtimeAnimatorController = attack3 as RuntimeAnimatorController;
                animationblock = 3;
                combo = 0;
                attackslide = 10;
            }
            else
            {
                release();
            }
            if (animationblock == 3)
            {
                attackslide -= 0.5f;
                transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, attackslide * Time.deltaTime);
            }
        }
    #endregion 

        //Debug.Log(animationblock);
    }

    private void release()
    {
        ///release into walk,idel animation
        if (this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !this.GetComponent<Animator>().IsInTransition(0))
        {
            animationblock = 0;
        }
    }
}
