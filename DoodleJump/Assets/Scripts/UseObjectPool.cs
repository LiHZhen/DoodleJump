using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseObjectPool : MonoBehaviour {
    private Rigidbody rb;
    void OnEnable()
    {
        StartCoroutine(ReturnToPool());
    }
    // Use this for initialization
    void Awake ()
    {
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator ReturnToPool()
    {
        yield return new WaitForSeconds(2f);
        rb.angularVelocity = Vector3.zero;
        rb.velocity = Vector3.zero;
        ObjectPool.instance.Return(this.gameObject);
    }
}
