using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour {
    //角色
    public GameObject m_Player;
    //background
    private GameObject m_Space_BG;
    //石头生成器
    private GameObject m_RockCreate;

    private Transform m_Transform;

    private float nextTime = 0;
    private float addTime = 4f;

    private bool life = true;
    private bool start = true;
    private bool gaming;
    private bool end;

    //private List<GameObject[]> mapList = new List<GameObject[]>();


    public  Vector3 m_Start_pos = new Vector3(0, -7f, -0.5f);
    Vector3 m_Space_pos = new Vector3(0,-7.5f,3f);
    Vector3 m_Space_rot = new Vector3(90f, 0, 0);
    //rockcreate
    Vector3 m_RockCreate_pos = new Vector3(0,0,8.766f);

    void Start()
    {
        //Resources动态加载物体 并强制转化为GameObject
        m_Player = Resources.Load("Player") as GameObject;
        m_Space_BG = Resources.Load("Space_BG") as GameObject;
        m_RockCreate = Resources.Load("RockCreate") as GameObject;

        //获取transform组件
        m_Transform = gameObject.GetComponent<Transform>();

        //设置物体缩放大小
        m_Player.GetComponent<Transform>().localScale = new Vector3(0.5f, 0.8f, 0.5f);
        m_Space_BG.GetComponent<Transform>().localScale = new Vector3(5.77f,11.54f,1);

    }

    void Update()
    {
        GameObject Player = null;
        GameObject Space_BG = null;
        if(start == true)
         {
            //生成角色
            Player = GameObject.Instantiate(m_Player, m_Start_pos, Quaternion.identity) as GameObject;
            //生成太空
            Space_BG = GameObject.Instantiate(m_Space_BG, m_Space_pos, Quaternion.Euler(m_Space_rot))as GameObject;
            
            Debug.Log("我出生啦");
            gaming = true;
            start = false;
         }
        if(Time.time>nextTime)
        {
            //RockCreate
            GameObject.Instantiate(m_RockCreate).GetComponent<Transform>().position = m_RockCreate_pos + new Vector3(Random.Range(-2.5f, 2.5f), 0, 0);
            nextTime += addTime;
        }
    }
}