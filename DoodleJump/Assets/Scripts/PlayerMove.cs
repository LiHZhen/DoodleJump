using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public bool isDown;//是否正在上升，在下降时碰撞到才施加力
    private Vector3 vec;

    private bool jump = true;
    private Rigidbody rig;

    public static bool isDead = false;
    void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
        isDead = false;
        transform.position=new Vector3(0,-0.873f,4);
        PlayUi.instance.source = 0;
    }
	void Start ()
    {
        vec = transform.position;
    }
	
	void Update ()
    {
        Move();
        if (!isDown)
        {
            jump = true;
        }
    }

    void FixedUpdate()
    {
        CheckDown();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Respawn" && isDown)//踩到踏板
        {
            if (jump)
            {
                rig.velocity = Vector3.zero;
                rig.AddForce(Vector3.up * 700);
                jump = false;
            }
        }
        else if(other.tag=="Monster"&& !isDown)//撞到怪物
        {
            Time.timeScale = 0;
            isDead = true;
            Debug.Log(1);
        }
        else if(other.tag=="Monster"&& isDown)//踩到怪物
        {
            if (jump)
            {
                rig.velocity = Vector3.zero;
                rig.AddForce(Vector3.up * 700);
                jump = false;
            }
        }
        else if (other.name == "Bottom")//踩到底部
        {
            Time.timeScale = 0;
            isDead = true;
        }
    }

    private void CheckDown()//检查角色是否在向下运动
    {
        if (vec.y - transform.position.y>0)
        {
            isDown = true;
        }
        else
        {
            isDown = false;
        }

        vec = transform.position;
    }

    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        transform.position+=new Vector3(x*Time.deltaTime*10,0,0);
        if (x > 0)
        {
            transform.rotation = Quaternion.Euler(0,180,0);
        }
        else if (x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        //角色到屏幕边界时移动到屏幕另一边
        if (transform.position.x <- 3.3f)
        {
            transform.position=new Vector3(3.7f,transform.position.y,transform.position.z);
        }
        else if (transform.position.x>3.7f)
        {
            transform.position = new Vector3(-3.3f, transform.position.y, transform.position.z);
        }
    }
}
