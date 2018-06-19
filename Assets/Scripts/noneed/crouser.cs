using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crouser : MonoBehaviour {

    public float Walkstate;

    public GameObject arrow;

    public GameObject Target;

    public float stop = 0;
    public float horizontalSpeed = 2.0F;
    public float verticalSpeed = 2.0F;

    // Use this for initialization
    void Start () {
        Cursor.visible = false;
    }
	
	// Update is called once per frame
	void Update () {

        //Screen.lockCursor = true;

        if (stop == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, 4 * Time.deltaTime);
        }

        if(stop == 0)
        {
            float h = horizontalSpeed * Input.GetAxis("Mouse X");
            float v = verticalSpeed * Input.GetAxis("Mouse Y");
            transform.Translate(h / 2, v / 2, 0);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Startidel")
        {
            Walkstate = 0;
            arrow.GetComponent<Renderer>().enabled = false;
        }

        if (collision.tag == "startrun")
        {
            Walkstate = 1;
        }

        if(collision.tag == "stopcrouser")
        {
            stop = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Startidel")
        {
            Walkstate = 1;
            arrow.GetComponent<Renderer>().enabled = true;
        }

        if (collision.tag == "startrun")
        {
            Walkstate = 2;
        }

        if (collision.tag == "stopcrouser")
        {
            stop = 1;
        }
    }
}
