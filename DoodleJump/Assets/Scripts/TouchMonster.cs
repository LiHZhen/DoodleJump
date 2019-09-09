using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMonster : MonoBehaviour
{
    private Rigidbody rig;
	// Use this for initialization
	void Awake ()
    {
        rig = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            rig.useGravity = true;
            Destroy(gameObject,2);
        }
        
    }
}
