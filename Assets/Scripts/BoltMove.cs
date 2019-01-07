using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltMove : MonoBehaviour {

    private Rigidbody m_Rigidbody;
    private float m_Speed = 20f;
	void Start () {
        m_Rigidbody = gameObject.GetComponent<Rigidbody>();

        //Debug.Log("time1:" + Time.time);
        

    }
    private void FixedUpdate()
    {
        m_Rigidbody.velocity = transform.forward * m_Speed;
        GameObject.Destroy(gameObject, 1f);
    }


}
