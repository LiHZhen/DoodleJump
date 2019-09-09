using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedal3Script : MonoBehaviour
{
    private Rigidbody rig;

    private PlayerMove player;
	// Use this for initialization
	void Awake ()
    {
        rig = GetComponent<Rigidbody>();
        player = GameObject.Find("Player").GetComponent<PlayerMove>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider other)
    {
        if (player.isDown&& player.isDown && other.tag == "Player")
        {
            rig.useGravity = true;
            Destroy(gameObject, 2);
        }
        
    }
}
