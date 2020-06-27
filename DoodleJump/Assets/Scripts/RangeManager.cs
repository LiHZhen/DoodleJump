using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeManager : UnitySingleton<RangeManager> {


    //public int[] range=new int[10];
    public List<int> range=new List<int>(10);

    private string rangeStr;

    void Awake()
    {
        if (!PlayerPrefs.HasKey("RangeText"))
        {
            PlayerPrefs.SetString("RangeText", "0,0,0,0,0,0,0,0,0,0");
        }

        rangeStr = PlayerPrefs.GetString("RangeText");

        for (int i = 0; i < range.Count; i++)
        {
            string str = rangeStr.Split(',')[i];
            range[i] = int.Parse(str);
        }
    }

    void Start()
    {
        
    }

    /// <summary>
    /// 检查分数是否能上排名
    /// </summary>
    /// <param name="value"></param>
    public void CheckoutRange(int value)
    {
        for (int i = 0; i < range.Count; i++)
        {
            if (range[i] < value)
            {
                range.Insert(i,value);
                return;
            }
            
        }
    }

    /// <summary>
    /// 保存记录
    /// </summary>
    public void SaveRange()
    {
        rangeStr = "";
        for (int i = 0; i < range.Count; i++)
        {

            if (i != 9)
            {
                rangeStr += range[i]+",";
            }
            else
            {
                rangeStr += range[i];
            }
        }
        Debug.Log(rangeStr);
        PlayerPrefs.SetString("RangeText",rangeStr);
    }

}
