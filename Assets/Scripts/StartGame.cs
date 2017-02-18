/*  --------------------------
 *  class StartGame
 *  --------------------------
 *  methods:
 *      onStartClick()
 *      onRestartClick()
 *      onToggleClick()
 *      onInstructionClick()
 *      onBackClick()
 *      onExitClick()
 *      volumeControl()
 *      endGame()
 *  --------------------------
 *  IEnumerators:
 *      StartCount()
 *  --------------------------
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {
    // Buttons
    public GameObject StartButton;
    public GameObject InstructionsButton;
    public GameObject ExitButton;
    public GameObject BackButton;
    public GameObject RestartButton;
    public GameObject RabbitButton;

    // Volume Controls
    public Slider VolumeSlider;
    public GameObject VolumeSliderObject;
    public AudioSource Source;

    // Characters
    public GameObject[] horses;
    public GameObject Rabbits;

    // Time
    public float timeLeft = 60.0f;
    private float currTime;
    public Text timeText;

    // Instructions
    public GameObject instructions;

    // Player Controls
    public GameObject Player;
    public GameObject MouseControlCamera;

    // Orchard Controller
    public GameObject OrchardController;
    
    // Scene
    private Scene currScene;
    
    
    //--DEFAULT METHODS--//
    void Start ()
    {
        currScene = SceneManager.GetActiveScene();
    }
	
	// Update is called once per frame
	void Update ()
    {
        // Press escape to end game only if you are currently playing
        if (Input.GetKeyDown("escape") && camera.GetComponent<MouseLook>().active)
        {
            endGame();
        }
    }

    //--CUSTOM METHODS--//

    /*
     *  This method is the starting point for gameplay,
     *  UI buttons are taken off the screen, movement is
     *  enabled, lemon spawning is activated, and the
     *  AI starts to move the horses.
     *
     * @params: none
     * 
     * @return: void
     */
    public void onStartClick()
    {
        // Enable controls
        Cursor.lockState = CursorLockMode.Locked;
        MouseControlCamera.GetComponent<MouseLook>().active = true;
        Player.GetComponent<Move>().enabled = true;

        // Start the clock
        currTime = Time.deltaTime;
        timeText.enabled = true;
        StartCoroutine(StartCount());

        // Turn off the buttons
        StartButton.SetActive(false);
        InstructionsButton.SetActive(false);
        ExitButton.SetActive(false);
        RabbitButton.SetActive(false);
        VolumeSliderObject.SetActive(false);

        
        // Start the horses
        horses[0].GetComponent<AI>().enabled = true;
        horses[1].GetComponent<AI>().enabled = true;

        // Start growing lemons
        OrchardController.GetComponent<OrchardController>().enabled = true;
        
    }

    /*
     *  This method reloads the scene and starts a 'new'
     *  game.
     *  
     *  @params: none
     *  
     *  @return: void 
     */ 
    public void onRestartClick()
    {
        SceneManager.LoadScene(currScene.buildIndex);
    }

    /*
     *  This method toggles the dancing bunnies on and
     *  off.
     *  
     *  @params: none
     *  
     *  @return: void
     */
    public void onToggleClick()
    {
        if (Rabbits.activeInHierarchy == true)
        {
            Rabbits.SetActive(false);
        }
        else
        {
            Rabbits.SetActive(true);
        }
           
    }

    /*
     *  This method shows the game instructions.
     *  
     *  @params: none
     *  
     *  @return: void
     */
    public void onInstructionsClick()
    {
        // Turn off buttons so screen is visible
        StartButton.SetActive(false);
        InstructionsButton.SetActive(false);
        ExitButton.SetActive(false);
        RabbitButton.SetActive(false);
        // Show the instructions
        instructions.SetActive(true);
        // Show the back button
        BackButton.SetActive(true);
    }

    /*
     *  This method hides the game instructions.
     *  
     *  @params: none 
     *
     *  @return: void
     */
    public void onBackClick()
    {
        // Hide the instructions
        instructions.SetActive(false);
        // Hide the back button
        BackButton.SetActive(false);

        // Show all other buttons
        StartButton.SetActive(true);
        InstructionsButton.SetActive(true);
        ExitButton.SetActive(true);
        RabbitButton.SetActive(true);
    }

    /*
     *  This method quits the game.
     *  
     *  @params: none
     *  
     *  @return: void 
     */
    public void onExitClick()
    {
        Application.Quit();
    }

    /*
     *  This method changes the volume level of 
     *  the audiosource.
     * 
     *  @params: none
     *
     *  @return: void
     */ 
    public void volumeControl()
    {
        Source.volume = VolumeSlider.value;
    }

    /*
     *  This method ends the current game, but does
     *  not quit the application. the mouse is released
     *  and the buttons are shown again.
     *  
     *  @params: none
     *  
     *  @return: void
     */
    private void endGame()
    {
        // Disable Controls
        Cursor.lockState = CursorLockMode.None;
        MouseControlCamera.GetComponent<MouseLook>().active = false;
        Player.GetComponent<Move>().enabled = false;

        // Show the exit and restart buttons
        ExitButton.SetActive(true);
        RestartButton.SetActive(true);


        // Turn off the horse AI
        for (int i = 0; i < horses.Length; i++)
        {
            horses[i].GetComponent<AI>().enabled = false;
        }

        // Turn off the orchard/ stop spawning lemons
        OrchardController.GetComponent<OrchardController>().enabled = false;
    }

    /*
     *  This method starts the count down and
     *  updates the game clock with the remaining time
     *  
     *  @params: none
     *  
     *  @return: null;
     * 
     */
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
}
