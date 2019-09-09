using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomScript : MonoBehaviour {
    private Transform cameraTransform;

    void Awake()
    {
        cameraTransform = GameObject.Find("Main Camera").GetComponent<Transform>();
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (cameraTransform.position.y-transform.position.y>13)
        {
            transform.position =new Vector3(transform.position.x, cameraTransform.position.y - 13, transform.position.z);
        }
    }
}
