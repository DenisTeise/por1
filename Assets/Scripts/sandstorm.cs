using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sandstorm : MonoBehaviour {

    public GameObject arena;
    public GameObject enemysinreach;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (enemysinreach.GetComponent<registerenemy>().enemyinreach <= 0)
        {
            arena.SetActive(false);
            arena.transform.position = enemysinreach.transform.position - new Vector3(15f, 0, 0);
        }
        else
        {
            arena.SetActive(true);
        }
	}
}
