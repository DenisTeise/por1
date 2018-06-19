using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitdetect : MonoBehaviour {

    //public GameObject enemy;
    //public GameObject arrow;
    private float hit = 0;
    //private float color = 1;
    private float wiggle;
    private float wiggleamount;

    public Transform around;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (hit == 1)
        {
            wiggleamount = 0.2f;
            wiggle = 1;
            //color -= 0.1f;
            hit = 0;

            around.position = (around.transform.position - new Vector3(0, 0, 0)) + Random.insideUnitSphere * (wiggleamount);
        }

        if (wiggle == 1)
        {
            wiggleamount -= 0.01f;
            around.position = (around.transform.position - new Vector3(0, 0, 0)) + Random.insideUnitSphere * (wiggleamount);
        }

        if (wiggleamount <= 0)
        {
            wiggle = 0;
        }

        //arrow.GetComponent<SpriteRenderer>().color = new Color(color, color, 1);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "enemy" )
        {
            hit = 1;
        }
    }
}
     