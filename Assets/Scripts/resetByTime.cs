using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class resetByTime : MonoBehaviour
{

    public Text text;
    public float resetTimer = 5.0f;
    private float reset;
    private bool resetActive = false;

    void Update()
    {
        if (Time.time > reset && resetActive)
        {
            text.text = "";
            resetActive = false;
        }
    }

    public void resetStart()
    {
        reset = Time.time + resetTimer;
        resetActive = true;
    }
}
