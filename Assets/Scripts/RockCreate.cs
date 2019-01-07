using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockCreate : MonoBehaviour {

    private Transform m_Tranform;

    private GameObject m_Rock_1;
    private GameObject m_Rock_2;
    private GameObject m_Rock_3;

    private float size_x;
    private float size_y;
    private float size_z;


	void Start () {
        GameObject item = null;

        size_x = Random.Range(0.2f, 0.5f);
        size_y = Random.Range(0.2f, 0.5f);
        size_z = Random.Range(0.2f, 0.5f);
        m_Rock_1 = Resources.Load("prop_asteroid_01") as GameObject;
        m_Rock_2 = Resources.Load("prop_asteroid_02") as GameObject;
        m_Rock_3 = Resources.Load("prop_asteroid_03") as GameObject;
        m_Tranform = gameObject.GetComponent<Transform>();
        switch ((int)Random.Range(1, 4))
        {
            case 1:
                item = GameObject.Instantiate(m_Rock_1);
                break;
            case 2:
                item = GameObject.Instantiate(m_Rock_2);
                break;
            case 3:
                item = GameObject.Instantiate(m_Rock_3);
                break;
        }
        item.AddComponent<Rigidbody>().velocity = new Vector3(0, 0, -1);
        item.AddComponent<Rock>();
        item.AddComponent<BoxCollider>().isTrigger = true;


        item.GetComponent<Transform>().localScale = new Vector3(size_x, size_y,size_z);
        item.GetComponent<Transform>().position = m_Tranform.position;
        item.GetComponent<Transform>().tag = "Rock";
        item.GetComponent<Rigidbody>().useGravity = false;
        item.GetComponent<BoxCollider>().size = new Vector3(size_x*3,size_y*3,size_z*3);
        
    }
}
