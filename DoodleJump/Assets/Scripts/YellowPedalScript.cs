using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowPedalScript : MonoBehaviour
{


    private SpriteRenderer sr;
    private PlayerMove player;
    private bool OnDestroy;
    private float a = 1;

    void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMove>();
        sr = GetComponent<SpriteRenderer>();
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (OnDestroy)
        {
            sr.color = new Color(255, 255, 255,a);
            a = Mathf.Lerp(a, 0, Time.deltaTime);
        }
	}
    void OnTriggerEnter(Collider other)
    {
        if (player.isDown&&other.tag=="Player")
        {
            OnDestroy = true;
            Destroy(gameObject, 2);
        }
    }
}
