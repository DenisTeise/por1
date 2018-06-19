using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camer : MonoBehaviour {

    public Camera cam;

    public GameObject player1;

    public GameObject target;
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;

    private float zoomouttime;
    private float gain;
    // Use this for initialization
    void Start () {

	}

    // Update is called once per frame
    void Update () {

        Vector3 targetPosition = target.transform.TransformPoint(new Vector3(0, 5, -10));
        cam.transform.position = Vector3.SmoothDamp(cam.transform.position, targetPosition, ref velocity, smoothTime);

        if (player1.GetComponent<player2>().moveSpeed == 0 && player1.GetComponent<player2>().fightstate == 0)
        {
            zoomouttime -= 1;
        }
        else
        {
            zoomouttime = 250;
        }

        if (player1.GetComponent<player2>().moveSpeed == 0 && cam.orthographicSize <= 15 && zoomouttime<=0)
        {
            gain += 0.0001f;
            cam.orthographicSize += (gain);
        }
        else
        if(cam.orthographicSize >= 5 && gain >=0)
        {
            gain -= 0.0001f;
            cam.orthographicSize -= (gain);
        }
        
    }
}
