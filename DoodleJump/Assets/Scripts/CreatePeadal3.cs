using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePeadal3 : MonoBehaviour
{

    private GameObject Pedal3;

    private float createX;
    private float createY;

    private GameObject player;
    private float source = 0;
    private float hard = 0;

    void Awake()
    {
        Pedal3 = Resources.Load("Pedal3")as GameObject;
        player = GameObject.Find("Player");
    }
	void Start ()
    {
        source = PlayUi.instance.source;
    }
	
	// Update is called once per frame
	void Update () {
        source = PlayUi.instance.source;
        if (source>hard+100)
        {
            hard = source;
            CreateTab(player.transform.position.y+12);
        }
    }
    void CreateTab(float y)
    {
        createX = Random.Range(-3f, 3f);
        createY = Random.Range(y+2, y-2);
        GameObject createTab = Instantiate(Pedal3, new Vector3(createX, createY, player.transform.position.z), Quaternion.identity);
        createTab.transform.parent = transform;
    }
}
