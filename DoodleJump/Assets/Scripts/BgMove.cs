using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgMove : MonoBehaviour {

    private Transform cameraTransform;

    void Awake()
    {
        cameraTransform = GameObject.Find("Main Camera").GetComponent<Transform>();
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (cameraTransform.position.y - transform.position.y >= 20f)
        {
            transform.position=new Vector3(transform.position.x,transform.position.y+30,transform.position.z);
        }
	}
}
