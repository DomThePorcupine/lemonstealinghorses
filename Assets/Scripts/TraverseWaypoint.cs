using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// This Script takes in a waypoint as a vector 3 and will lerp gameobject to that point
/// will control isReady boolean of the AI script
/// </summary>
public class TraverseWaypoint : MonoBehaviour {/*
    public float speed = 2.0f;


    private AI aiScript;
    private Vector3 desiredVelocity;
    private float lastSqrMagnitude;
    private Rigidbody rb;
    private Vector3 targetPoint;
	// Use this for initialization
	void Start () {
        aiScript = GetComponent<AI>();
        rb = GetComponent<Rigidbody>();
        //set it to a position so rb should not move until a new targetPoint is set
        targetPoint = transform.position;
        //aiScript.isReady = true;
	}
	
	// Update is called once per frame
	void Update () {
        float sqrMagnitude = (targetPoint - transform.position).sqrMagnitude;

        //if true, we have reached waypoint, stop moving and 
        //set AI isReady to true so another target can be input
        if (sqrMagnitude > lastSqrMagnitude)
        {
            desiredVelocity = Vector3.zero;
            aiScript.isReady = true;
        }

        //updates lastSqrMagnitude
        lastSqrMagnitude = sqrMagnitude;
    }


    //This moves character
    void FixedUpdate()
    {
        rb.velocity = desiredVelocity;
        if (rb.velocity != Vector3.zero)
        {
            transform.forward = -rb.velocity;
        }
    }

    public void traverse(Vector3 targetPoint)
    {
        this.targetPoint = targetPoint;
        //set AI isReady to false so it does not send another target
        aiScript.isReady = false;

        //finds distance between current position and target, normalizes it and
        //multiplies it by speed so speed is consistent.
        //!!!!!!make sure target.position.y and this.transform.y are same so no movement happens on y axis
        Vector3 directionalVector = (targetPoint - transform.position).normalized * speed;
     
        //reset lastSqrMagnitude to prevent mistakes
        lastSqrMagnitude = Mathf.Infinity;

        //set global variable to be used in other methods
        desiredVelocity = directionalVector;
    }
    */
}
