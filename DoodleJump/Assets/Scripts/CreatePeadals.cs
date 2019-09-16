using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePeadals : MonoBehaviour {
    
    private GameObject pedal1;
    private float high = 4.3f;//静止弹跳时最大距离为4.3，故每一块pedal的y轴之间最大距离不能超过4.3

    private float createMaxY = 12;//创建踏板时y轴与角色的最大距离
    private float minHigh;
    //创建时的坐标
    private float createX;
    private float createY;
    private GameObject player;

    private int pedalCount = 5;//难度，范围内创建踏板的最大次数
    //private PlayUi sourseScript;
    private float source=0;
    private float hard=0;

    private int ran1=1;
    private int yellowRank=3;
    private int blueRank =0;
    private int writeRank = 0;

    public int hardSource=500;

    void Awake()
    {
        pedal1 = Resources.Load("pedal1") as GameObject;
        //sourseScript = GameObject.Find("MainCanvas/PlayUi").GetComponent<PlayUi>();
        player =GameObject.Find("Player");
    }
    void Start ()
    {
        minHigh = -4;
        CreateTab(player.transform.position.y + high, player.transform.position.y);
    }
	
	// Update is called once per frame
	void Update ()
    {
        Create();
    }

    void Create()
    {
        source = PlayUi.instance.source;
        if (minHigh + high <= player.transform.position.y + createMaxY)//创建踏板到离角色y轴createMaxY单位一下的位置
        {
            minHigh += high / 2;
            CreateTab(minHigh + high / 2, minHigh);
            if (pedalCount == 1)//创建第五踏板
            {
                ran1 = Random.Range(1, 5);
                if (writeRank > 0)
                {
                    if (ran1 >= writeRank)
                    {
                        pedal1 = Resources.Load("Pedal2") as GameObject;
                    }
                    else
                    {
                        pedal1 = Resources.Load("Pedal5") as GameObject;
                    }

                }
                else if (blueRank > 0)
                {
                    if (ran1>=blueRank)
                    {
                        pedal1 = Resources.Load("Pedal5") as GameObject;
                    }
                    else
                    {
                        pedal1 = Resources.Load("Pedal4") as GameObject;
                    }
                    
                }
                else if (ran1 >= yellowRank)
                {
                    pedal1 = Resources.Load("Pedal4") as GameObject;
                }
                else
                {
                    pedal1 = Resources.Load("pedal1") as GameObject;
                }


            }
        }

        if (source >= hard + hardSource && pedalCount > 1)//分数每多100生成的踏板减少1
        {
            hard = source;
            pedalCount--;
        }

        if (source > hard + hardSource && yellowRank > 1)
        {
            hard = source;
            yellowRank--;
        }

        else if (yellowRank == 1&&blueRank==0)
        {
            blueRank = 3;
        }

        if (source > hard + hardSource && blueRank > 1)
        {
            hard = source;
            blueRank--;
        }
        else if (blueRank == 1&&writeRank==0)
        {
            writeRank = 3;
        }
        if (source > hard + hardSource && writeRank > 1)
        {
            hard = source;
            writeRank--;
        }
    }

    void CreateTab(float maxY,float minY)
    {
        if (PlayUi.instance.source>hardSource*3)
        {
            high = 8.4f;
            maxY = minY;
            if (PlayUi.instance.source > hardSource*6)
            {
                Time.timeScale = 1.1f;
            }
        }
        for (int i = 0; i < pedalCount; i++)
        {
            createX = Random.Range(-3f, 3f);
            createY = Random.Range(maxY, minY);
            GameObject createTab = Instantiate(pedal1, new Vector3(createX, createY, player.transform.position.z+0.5f),Quaternion.identity);
            createTab.transform.parent = transform;
        }
    }
}
