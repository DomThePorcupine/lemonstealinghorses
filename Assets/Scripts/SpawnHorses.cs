using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHorses : MonoBehaviour {

    public GameObject[] horses;

    public StartGame startGame;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(startGame.timeLeft < 45 && !horses[0].activeSelf)
        {
            horses[0].SetActive(true);
        }

        if (startGame.timeLeft < 30 && !horses[1].activeSelf)
        {
            horses[1].SetActive(true);
        }
        if (startGame.timeLeft < 15 && !horses[2].activeSelf)
        {
            horses[2].SetActive(true);
        }
    }
}
