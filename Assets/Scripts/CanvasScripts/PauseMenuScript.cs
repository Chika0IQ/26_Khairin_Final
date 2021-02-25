using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuScript : MonoBehaviour
{

    //Variables//

    public static bool GamePaused = false; // Bool to check if the GamePaused is true or false
    private bool isMuted; // Check if player mutes the game

    public GameObject pauseMenuUI; // Set the pauseMenuUI as a GameObject and to Public so it can be reference in the Inspector
    public Slider volSlider; // Set the volSlider to Public and Reference the Slider UI Element in the Inspector
    public Toggle muteChk; // Set Toggle UI to public to check if player has clicked the mute CheckBox
    public AudioSource bgmAudio; // Referencing the AudioSource

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        //Player Input Conditions//
        if (Input.GetKeyDown(KeyCode.Escape)) // Checks if player presses on the Escape Button 
        {
            if (GamePaused) // Check if the Game is paused, if so, will can the Resume function, if not, will call the Pause Function Instead 
            {
                Resume();
            }
            else if (ShopUIScript.shopPaused == false) // Referencing the ShopUiScript to check if it is Active or not, if not, call Pause Function
            {
                Pause();
            }
        }
    }


    //Resume Function that just resume that game and will not change anything unless it was paused before only then will it the values below
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
    }


    // Pause Function will enable the PauseUI element, set the speed of the whole game to be 0 so nothing will be moving, setting the bool GamePaused to true
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }


    // BGMMute Funtionc that will be on the Mute BGM button and will mute only the BGM
    public void BgmMute()
    {
        isMuted = !isMuted;
        AudioListener.pause = isMuted;
    }


    // Volume slider that will corespond with audio levels in the whole game 
    public void SetVol(float vol)
    {
        AudioListener.volume = vol;
    }
}