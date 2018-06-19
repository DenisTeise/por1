using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class crouser3 : NetworkBehaviour
{ 
    public GameObject Target;

    public GameObject zeiger;

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

        if (isLocalPlayer)
        {
            return;
        }

        //Screen.lockCursor = true;

        if (stop == 1)
        {
            zeiger.transform.position = Vector3.MoveTowards(zeiger.transform.position, Target.transform.position, 5 * Time.deltaTime);
        }

        if (stop == 0)
        {
            float h = horizontalSpeed * Input.GetAxis("leftstickhorizantal");
            float v = verticalSpeed * Input.GetAxis("leftstickvertical");
            zeiger.transform.Translate(h / 2, v / 2, 0);
        }

    }
}
