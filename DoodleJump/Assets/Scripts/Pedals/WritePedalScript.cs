using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WritePedalScript : MonoBehaviour {

    private PlayerMove player;

    private BluePedalScript bluePedal;
    // Use this for initialization
    void Awake () {
        player = GameObject.Find("Player").GetComponent<PlayerMove>();
        bluePedal = Resources.Load<BluePedalScript>("Pedal5");
    }

    void Start()
    {
        if (PlayUi.instance.source>=1000)
        {
            gameObject.AddComponent<BluePedalScript>();
        }
    }
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (player.isDown && other.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
