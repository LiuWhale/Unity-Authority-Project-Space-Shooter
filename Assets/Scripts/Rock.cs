using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour {
    private GameObject m_Expolisive;

    private Transform m_Transform;
    Vector3 rot;

    void Start () {
        m_Transform = gameObject.GetComponent<Transform>();
        m_Expolisive = Resources.Load("explosion_asteroid") as GameObject;
        rot = new Vector3(Random.Range(0, 90), Random.Range(0, 90), Random.Range(0, 90));
    }
	

	void Update () {
        m_Transform.Rotate(rot*Time.deltaTime);
        GameObject.Destroy(gameObject, 10f);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bolt"||other.tag =="Player")
        {
            GameObject item = GameObject.Instantiate(m_Expolisive,m_Transform.position,Quaternion.identity);
            GameObject.Destroy(gameObject);
            GameObject.Destroy(item,1f);
        }
        
    }
}
