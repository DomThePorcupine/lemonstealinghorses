using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorsePunched : MonoBehaviour {

    public float timeInvincible;

    private bool wasPunched;
    private bool invincible;
    private float timeNoLongerInvincible;
    private TraverseWaypoint travWP;
	// Use this for initialization
	void Start () {
        travWP = GetComponent<TraverseWaypoint>();
	}
	
	// Update is called once per frame
	void Update () {
        if (wasPunched && !invincible && Time.time >= timeNoLongerInvincible)
        {
            timeNoLongerInvincible = Time.time + timeInvincible;
            invincible = true;
        }
        if(Time.time >= timeNoLongerInvincible)
        {
            wasPunched = false;
            invincible = false;
            travWP.enabled = true;
        }
    }

    void FixedUpdate()
    {
        //if punched, knock backwards and then set invincible

    }

    public int punched()
    {
        int tempSub = 0;
        wasPunched = true;
        travWP.enabled = false;
        if (!invincible)
        {
            int temp = Random.Range(0, 2);
            if (temp == 0)
            {
                tempSub = (int) (GetComponent<HeldLemons>().lemons - Mathf.Floor(GetComponent<HeldLemons>().lemons / 2.0f));
                GetComponent<HeldLemons>().lemons -= tempSub;
            }
            else
            {
                tempSub = (int)(GetComponent<HeldLemons>().lemons - Mathf.Ceil(GetComponent<HeldLemons>().lemons / 2.0f));
                GetComponent<HeldLemons>().lemons -= tempSub;
            }
            print("punched for " + tempSub + " lemons");
        }
        return tempSub;
       // Vector3 hitForce = Vector3.
    }
}
