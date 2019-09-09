using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private float rotationZ;
    private Transform shootPoint;
    private Rigidbody rb;
    private Quaternion quaternion;

    void Awake()
    {
        shootPoint = GameObject.Find("Player/ShootPoint").GetComponent<Transform>();
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            rotationZ = Random.Range(-30f, 30f);
            GameObject obj=ObjectPool.instance.Get("Bullet", shootPoint.position,shootPoint.rotation)as GameObject;
            rb =obj.GetComponent<Rigidbody>();
            rb.AddForce(Vector3.up*1000);
        }
	}
    
}
