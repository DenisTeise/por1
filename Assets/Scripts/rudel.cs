using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rudel : MonoBehaviour {

    public GameObject player;
    public GameObject wolf;

    public float chase;

    private float members;

	// Use this for initialization
	void Start () {
        members = Random.Range(6, 15);

	}
	
	// Update is called once per frame
	void Update () {

        float distance = Vector3.Distance(player.transform.position, transform.position);

        if (members >= 0 && distance <= 20)
        {
            Instantiate(wolf, transform.position, Quaternion.identity, this.transform);
            members -= 1;
        }

        if (distance <= 20)
        {
            chase = 1;
        }
    }
}
