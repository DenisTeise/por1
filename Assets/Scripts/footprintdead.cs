using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footprintdead : MonoBehaviour {

    private float dead;

	// Use this for initialization
	void Start () {
        dead = Random.Range(300, 1000);
	}
	
	// Update is called once per frame
	void Update () {
        dead -= 1;

        if (dead <= 0)
        {
            Destroy(gameObject);
        }
    }
}
