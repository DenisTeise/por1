using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recivehit : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "enemyattack")
        {
            GetComponentInParent<player2>().hit = 1;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "enemyattack")
        {
            GetComponentInParent<player2>().hit = 0;
        }
    }
}
