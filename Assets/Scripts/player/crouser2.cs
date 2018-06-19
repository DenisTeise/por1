using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crouser2 : MonoBehaviour
{

    public GameObject Target;

    public float stop = 0;
    public float Walkstate;
    public GameObject arrow;

    public float horizontalSpeed = 2.0F;
    public float verticalSpeed = 2.0F;

    // Use this for initialization
    void Start()
    {
        Cursor.visible = false;
        
    }

    // Update is called once per frame
    void Update()
    {


            //Screen.lockCursor = true;

            if (stop == 1)
            {
                transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, 5 * Time.deltaTime);
            }

            if (stop == 0)
            {
                float h = horizontalSpeed * Input.GetAxis("leftstickhorizantal");
                float v = verticalSpeed * Input.GetAxis("leftstickvertical");
                transform.Translate(h / 2, v / 2, 0);
            }

            if (Vector3.Distance(transform.position, Target.transform.position) < 0.7f)
            {
                Walkstate = 0;
                arrow.GetComponent<Renderer>().enabled = false;
            }

            if (Vector3.Distance(transform.position, Target.transform.position) > 0.7f && Vector3.Distance(transform.position, Target.transform.position) < 1f)
            {
                Walkstate = 1;
                arrow.GetComponent<Renderer>().enabled = true;
            }

            if (Vector3.Distance(transform.position, Target.transform.position) > 1f)
            {
                Walkstate = 2;
            }

            if (Vector3.Distance(transform.position, Target.transform.position) > 2f)
            {
                stop = 1;
            }
            else
            {
                stop = 0;
            }
        
    }
}
