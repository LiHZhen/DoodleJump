using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedalScript : MonoBehaviour
{

    private Transform cameraTransform;

    void Awake()
    {
        cameraTransform = GameObject.Find("Main Camera").GetComponent<Transform>();
    }
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y < cameraTransform.position.y-5.05f)
        {
            Destroy(gameObject);
        }
	}
}
