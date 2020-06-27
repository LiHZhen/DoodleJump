using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePedalScript : MonoBehaviour
{

    private float speed=2f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
        if (transform.position.x < -3f|| transform.position.x > 3f)
        {
            speed *= -1;
        }

	}
}
