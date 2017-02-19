using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowboyPunch : MonoBehaviour {/*
    public float punchPower = 500.0f;
    public ForceMode typeOfForce;
    public OrchardController controller;

    private bool isPunching = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerStay(Collider other)
    {

        if (Input.GetKeyDown(KeyCode.E) && other.tag.Equals("Horse") && !isPunching)
        {
            isPunching = true;
            print("You done hit a horse!");
            HorsePunched horseP = other.GetComponent<HorsePunched>();
            int stolenLemons = horseP.punched();
            Rigidbody horseRB = other.GetComponent<Rigidbody>();
            horseRB.AddForce(this.transform.forward * punchPower, typeOfForce);
            controller.stolen(stolenLemons);
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            isPunching = false;
        }
    }
    */
}
