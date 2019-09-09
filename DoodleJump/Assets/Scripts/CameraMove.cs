using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    private Transform PlayerTransform;


	// Use this for initialization
	void Awake ()
    {
        PlayerTransform = GameObject.Find("Player").GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        CheckPlayerHeight();

    }

    private void CheckPlayerHeight()
    {
        if (transform.position.y < PlayerTransform.position.y-1)
        {
            transform.position=new Vector3(transform.position.x,PlayerTransform.position.y-1,transform.position.z);
        }
        else if (transform.position.y-4.3f > PlayerTransform.position.y)
        {
            
            //Vector3 lerpStart= new Vector3(transform.position.x, PlayerTransform.position.y+5, transform.position.z);
            //Vector3 lerpEnd= new Vector3(transform.position.x, PlayerTransform.position.y-10 , transform.position.z);
            //transform.position = Vector3.Lerp(lerpStart, lerpEnd, 10f*Time.deltaTime);

            transform.position = new Vector3(transform.position.x, PlayerTransform.position.y + 4.3f, transform.position.z);
        }
    }
}
