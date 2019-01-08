using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public Transform m_Transform;
    public Transform m_ShotSpot;

    private GameObject m_Bolt;
    public GameObject item;

    //private List<GameObject[]> boltLists = new List<GameObject[]>();
    private float m_Player_z;
    private float m_Player_x;
    //边界
    private float MAX_x = 2.7f;
    private float MAX_z = 7.4f;
    private float MIN_x = -2.7f;
    private float MIN_z = -1f;
    private float speed = 0.1f;
    private float timescale = 0.20f;
    private float nextTime = 0.5f;    

    private bool UP;
    private bool DOWN;
    private bool LEFT;
    private bool RIGHT;

    Vector3 m_Rot = new Vector3(0, 0, 0);
    Vector3 L_rot = new Vector3(0, 0, 38);
    Vector3 R_rot = new Vector3(0, 0, -38);
    Vector3 Up_rot = new Vector3(30, 0, 0);
    Vector3 Down_rot = new Vector3(-30, 0, 0);

    private MapManager m_MapManager;

    void Start () {
        //获取组件
        m_Transform = gameObject.GetComponent<Transform>();
        m_ShotSpot = m_Transform.Find("ShotSpot").GetComponent<Transform>();
        m_MapManager =GameObject.Find("MapManager").GetComponent<MapManager>();

        m_Bolt = Resources.Load("Bolt") as GameObject;
        
        //获取起始坐标
        m_Player_x = m_MapManager.m_Start_pos.x;
        m_Player_z = m_MapManager.m_Start_pos.z;

    }

    private void PlayerMove()
    {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                UP = true;
                m_Transform.SetPositionAndRotation(m_Transform.position, Quaternion.Euler(Up_rot));
        }
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                UP = false;
                m_Transform.SetPositionAndRotation(m_Transform.position, Quaternion.Euler(m_Rot));
        }
            if (UP && m_Player_z < MAX_z )
            {
                m_Player_z +=speed;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                DOWN = true;
                m_Transform.SetPositionAndRotation(m_Transform.position, Quaternion.Euler(Down_rot));
        }
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                DOWN = false;
                m_Transform.SetPositionAndRotation(m_Transform.position, Quaternion.Euler(m_Rot));
        }
            if (DOWN && m_Player_z > MIN_z)
            {
                m_Player_z -=speed;
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                LEFT = true;
                m_Transform.SetPositionAndRotation(m_Transform.position, Quaternion.Euler(L_rot));
        }
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                LEFT = false;
                m_Transform.SetPositionAndRotation(m_Transform.position, Quaternion.Euler(m_Rot));
        }
            if (LEFT&& m_Player_x>MIN_x)
            {
                m_Player_x -=speed;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                RIGHT = true;
                m_Transform.SetPositionAndRotation(m_Transform.position, Quaternion.Euler(R_rot));
        }
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                RIGHT = false;
                m_Transform.SetPositionAndRotation(m_Transform.position, Quaternion.Euler(m_Rot));
        }
            if (RIGHT && m_Player_x<MAX_x)
            {
                m_Player_x+=speed;
            }
    
    }

	void Update () {
        m_Transform.position = Vector3.Lerp(m_Transform.position, new Vector3(m_Player_x, 0, m_Player_z), 4 * Time.deltaTime);
        
        if ((UP || DOWN || LEFT || RIGHT)&& Time.time > nextTime)
        {                
                item = GameObject.Instantiate(m_Bolt, m_ShotSpot.position, m_ShotSpot.rotation);
                Debug.Log("time0:"+Time.time);
                nextTime = Time.time+timescale;
        }
        PlayerMove();      
    }
}

