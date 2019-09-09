using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour {

    private GameObject mainCanvas = null;

    void Awake()
    {
        mainCanvas = GameObject.Find("MainCanvas(Clone)");
        if (mainCanvas == null)
        {
            Instantiate(Resources.Load("UIPrefabs/MainCanvas"));
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
