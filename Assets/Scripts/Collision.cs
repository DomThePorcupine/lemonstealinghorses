using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour {
    public GameObject obj;
    public GameObject toCreate;
    public Transform loc;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter()
    {
        obj.SetActive(false);
        // Vector3 pos = obj.transform.position;
        GameObject proj = Instantiate(toCreate,
                 loc.position, Quaternion.identity) as GameObject;
       // Instantiate(toCreate, obj.transform);
    }
}
