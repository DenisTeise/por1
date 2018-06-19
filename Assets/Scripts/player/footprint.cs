using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footprint : MonoBehaviour {

    private float timer;

    private float foot = 0;

    public GameObject Footprint;
    public GameObject secondfootprint;

    public GameObject arrowrotation;
    public GameObject playerposition;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        timer -= 1;

        if (timer <= 0 && foot == 0)
        {
            foot = 1;
            timer = 10;
            Instantiate(Footprint, playerposition.transform.position - new Vector3(0,0.7f,0), arrowrotation.transform.rotation);
        }

        if (timer <= 0 && foot == 1)
        {
            foot = 0;
            timer = 10;
            Instantiate(Footprint, playerposition.transform.position - new Vector3(0.1f, 0.6f, 0), arrowrotation.transform.rotation);
        }
    }
}
