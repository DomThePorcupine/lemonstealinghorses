using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {
    public GameObject setMove1;
    public GameObject[] horses;
    public GameObject StartButton;
    public GameObject InstructionsButton;
    public GameObject ExitButton;
    public GameObject BackButton;
    public GameObject RestartButton;
    public GameObject instructions;
    public GameObject OrchardController;
    public GameObject RabbitButton;
    public GameObject Rabbits;
    public GameObject camera;
    public Text timeText;
    private Scene currScene;
    public Slider overallSlider;
    public GameObject sliderToDisable;
    public AudioSource source;
    public float timeLeft = 60.0f;
    private float currTime; 
    // private SceneSetup SceneManager;
    // Use this for initialization
    public void volumeControl()
    {
        source.volume = overallSlider.value;
    }
    void Start ()
    {
        currScene = SceneManager.GetActiveScene();
       
        //StartTime = Time.deltaTime;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown("escape"))
        {
            camera.GetComponent<MouseLook>().active = false;
            Cursor.lockState = CursorLockMode.None;
        }
    }
    private void endGame()
    {
        Cursor.lockState = CursorLockMode.None;
        camera.GetComponent<MouseLook>().active = false;
        //set needed buttons
        ExitButton.SetActive(true);
        RestartButton.SetActive(true);


        //disable movement
        setMove1.GetComponent<Move>().enabled = false;
        for (int i = 0; i < horses.Length; i++)
        {
            horses[i].GetComponent<AI>().enabled = false;
        }
        OrchardController.GetComponent<OrchardController>().enabled = false;
    }

    public void onToggleClick()
    {
        if (Rabbits.activeInHierarchy == true)
        {
            Rabbits.SetActive(false);
        }
        else
            Rabbits.SetActive(true);
    }

    public void onStartClick()
    {
        currTime = Time.deltaTime;
        timeText.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        camera.GetComponent<MouseLook>().active = true;
        //set buttons to false
        StartButton.SetActive(false);
        InstructionsButton.SetActive(false);
        ExitButton.SetActive(false);
        RabbitButton.SetActive(false);
        sliderToDisable.SetActive(false);
        
        //RestartButton.SetActive(true);

        //start to allow movement
        setMove1.GetComponent<Move>().enabled = true;
        horses[0].GetComponent<AI>().enabled = true;
        horses[1].GetComponent<AI>().enabled = true;
        OrchardController.GetComponent<OrchardController>().enabled = true;
        StartCoroutine(StartCount());
    }

    IEnumerator StartCount()
    {
        while (true)
        {
            timeLeft -= Time.deltaTime;
            timeText.text = "Time Left: " + Mathf.Round(timeLeft);
            if (timeLeft <= 0)
            {
                endGame();
                break;
            }
            yield return null;
        }
    }

    public void onRestartClick()
    {
        SceneManager.LoadScene(currScene.buildIndex);
    }

    public void onInstructionsClick()
    {
        //set buttons to false
        StartButton.SetActive(false);
        InstructionsButton.SetActive(false);
        ExitButton.SetActive(false);
        RabbitButton.SetActive(false);

        //set text true and back button true
        instructions.SetActive(true);
        BackButton.SetActive(true);
    }
    public void onBackClick()
    {
        //set back false and text false
        instructions.SetActive(false);
        BackButton.SetActive(false);

        //set buttons to true
        StartButton.SetActive(true);
        InstructionsButton.SetActive(true);
        ExitButton.SetActive(true);
        RabbitButton.SetActive(true);
    }

    public void onExitClick()
    {
        Application.Quit();
    }
}
