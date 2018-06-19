using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wdead : MonoBehaviour {

    public GameObject Target;

    private float moveSpeed = -10;
    private float rotation;

	// Use this for initialization
	void Start () {
        Target = GameObject.Find("player (1)");
        rotation = Random.Range(0,1000);
        transform.rotation = Quaternion.Euler(0, 0, rotation);

        gameObject.tag = "dead";
        gameObject.GetComponent<Collider2D>().enabled = true;
	}
	
	// Update is called once per frame
	void Update () {

        if (moveSpeed <= 0)
        {
            moveSpeed = moveSpeed + 0.5f;
            transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, (moveSpeed * Time.deltaTime));
        }

    }
}
