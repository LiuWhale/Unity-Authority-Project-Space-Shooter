using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour {

    private Transform m_Transform;
    Vector3 rot;

    void Start () {
        m_Transform = gameObject.GetComponent<Transform>();
        rot = new Vector3(Random.Range(0, 90), Random.Range(0, 90), Random.Range(0, 90));
    }
	

	void Update () {
        m_Transform.Rotate(rot*Time.deltaTime);
        GameObject.Destroy(gameObject, 10f);
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player"||other.tag == "Bolt")
        {
            Debug.Log("我是一个小小石头！bang！");
            GameObject.Destroy(gameObject, 0.5f);
        }
    }
}
