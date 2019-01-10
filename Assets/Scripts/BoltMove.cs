using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltMove : MonoBehaviour {

    private Rigidbody m_Rigidbody;


    private float m_Speed = 15f;
	void Start () {
        m_Rigidbody = gameObject.GetComponent<Rigidbody>();
        
        //Debug.Log("time1:" + Time.time);

    }
    private void Update()
    {
        m_Rigidbody.velocity = transform.forward * m_Speed;
        GameObject.Destroy(gameObject, 1f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag =="Rock")
        {
            GameObject.Destroy(gameObject);
        }
    }
}
