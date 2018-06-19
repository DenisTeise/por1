using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blood : MonoBehaviour {

    public GameObject bloodparticle1;
    public GameObject bloodparticle2;
    public GameObject bloodparticle3;
    public GameObject bloodparticle4;
    public GameObject bloodparticle5;
    public GameObject bloodparticle6;
    public GameObject bloodparticle7;
    public GameObject bloodparticle8;
    public GameObject bloodparticle9;
    public GameObject bloodparticle10;

    public float radius;
    public float spawnblood;
    private float spamnbloot = -1;
    private float bloodparticle = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if ( spamnbloot >= 0)
        {
            spamnbloot -= 1;
            bloodparticle = Random.Range(1, 11);
        }
        else
        {
            bloodparticle = 0;
        }

        if (bloodparticle == 1)
        {
            Instantiate(bloodparticle1, transform.position + Random.insideUnitSphere * radius, Quaternion.identity);
            Instantiate(bloodparticle1, transform.position + Random.insideUnitSphere * radius, Quaternion.identity);
            Instantiate(bloodparticle2, transform.position + Random.insideUnitSphere * radius, Quaternion.identity);
            Instantiate(bloodparticle4, transform.position + Random.insideUnitSphere * radius, Quaternion.identity);
        }

        if (bloodparticle == 2)
        {
            Instantiate(bloodparticle2, transform.position + Random.insideUnitSphere * radius, Quaternion.identity);
            Instantiate(bloodparticle4, transform.position + Random.insideUnitSphere * radius, Quaternion.identity);
            Instantiate(bloodparticle3, transform.position + Random.insideUnitSphere * radius, Quaternion.identity);
            Instantiate(bloodparticle3, transform.position + Random.insideUnitSphere * radius, Quaternion.identity);
        }

        if (bloodparticle == 3)
        {
            Instantiate(bloodparticle3, transform.position + Random.insideUnitSphere * radius, Quaternion.identity);
            Instantiate(bloodparticle3, transform.position + Random.insideUnitSphere * radius, Quaternion.identity);
            Instantiate(bloodparticle4, transform.position + Random.insideUnitSphere * radius, Quaternion.identity);
            Instantiate(bloodparticle7, transform.position + Random.insideUnitSphere * radius, Quaternion.identity);
        }

        if (bloodparticle == 4)
        {
            Instantiate(bloodparticle4, transform.position + Random.insideUnitSphere * radius, Quaternion.identity);
            Instantiate(bloodparticle7, transform.position + Random.insideUnitSphere * radius, Quaternion.identity);
            Instantiate(bloodparticle5, transform.position + Random.insideUnitSphere * radius, Quaternion.identity);
            Instantiate(bloodparticle9, transform.position + Random.insideUnitSphere * radius, Quaternion.identity);
        }

        if (bloodparticle == 5)
        {
            Instantiate(bloodparticle5, transform.position + Random.insideUnitSphere * radius, Quaternion.identity);
            Instantiate(bloodparticle9, transform.position + Random.insideUnitSphere * radius, Quaternion.identity);
            Instantiate(bloodparticle6, transform.position + Random.insideUnitSphere * radius, Quaternion.identity);
            Instantiate(bloodparticle5, transform.position + Random.insideUnitSphere * radius, Quaternion.identity);
        }

        if (bloodparticle == 6)
        {
            Instantiate(bloodparticle6, transform.position + Random.insideUnitSphere * radius, Quaternion.identity);
            Instantiate(bloodparticle5, transform.position + Random.insideUnitSphere * radius, Quaternion.identity);
            Instantiate(bloodparticle7, transform.position + Random.insideUnitSphere * radius, Quaternion.identity);
            Instantiate(bloodparticle5, transform.position + Random.insideUnitSphere * radius, Quaternion.identity);
        }

        if (bloodparticle == 7)
        {
            Instantiate(bloodparticle7, transform.position + Random.insideUnitSphere * radius, Quaternion.identity);
            Instantiate(bloodparticle5, transform.position + Random.insideUnitSphere * radius, Quaternion.identity);
            Instantiate(bloodparticle8, transform.position + Random.insideUnitSphere * radius, Quaternion.identity);
            Instantiate(bloodparticle2, transform.position + Random.insideUnitSphere * radius, Quaternion.identity);
        }

        if (bloodparticle == 8)
        {
            Instantiate(bloodparticle8, transform.position + Random.insideUnitSphere * radius, Quaternion.identity);
            Instantiate(bloodparticle2, transform.position + Random.insideUnitSphere * radius, Quaternion.identity);
            Instantiate(bloodparticle9, transform.position + Random.insideUnitSphere * radius, Quaternion.identity);
            Instantiate(bloodparticle3, transform.position + Random.insideUnitSphere * radius, Quaternion.identity);
        }

        if (bloodparticle == 9)
        {
            Instantiate(bloodparticle9, transform.position + Random.insideUnitSphere * radius, Quaternion.identity);
            Instantiate(bloodparticle3, transform.position + Random.insideUnitSphere * radius, Quaternion.identity);
            Instantiate(bloodparticle10, transform.position + Random.insideUnitSphere * radius, Quaternion.identity);
            Instantiate(bloodparticle1, transform.position + Random.insideUnitSphere * radius, Quaternion.identity);
        }

        if (bloodparticle == 10)
        {
            Instantiate(bloodparticle10,transform.position + Random.insideUnitSphere * radius, Quaternion.identity);
            Instantiate(bloodparticle1, transform.position + Random.insideUnitSphere * radius, Quaternion.identity);
            Instantiate(bloodparticle1, transform.position + Random.insideUnitSphere * radius, Quaternion.identity);
            Instantiate(bloodparticle1, transform.position + Random.insideUnitSphere * radius, Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "sword")
        {
            spamnbloot = spawnblood;
        }
    }
}
