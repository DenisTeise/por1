using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bloodmovement : MonoBehaviour {

    private float x;
    private float y;

    private float rotation;
    private float roatationspeed;

    // Use this for initialization
    void Start () {

        y = Random.Range(0, 0.01f);
        x = Random.Range(-0.01f, 0.01f);

        roatationspeed = Random.Range(20, 50);
    }
	
	// Update is called once per frame
	void Update () {

        x = x * x;
        y = y * y;

        transform.position += new Vector3(x, y,  0);


        if (roatationspeed > 0)
        {
            roatationspeed -= 0.3f;
        }

        if (roatationspeed < 0)
        {
            roatationspeed = 0;
            rotation = 0;
            this.enabled = false;
        }

        rotation -= roatationspeed;
        transform.rotation = Quaternion.Euler(0, 0, rotation);

	}
}
