using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuScript : MonoBehaviour
{

    public static bool GamePaused = false;


    public GameObject pauseMenuUI;
    public Slider volSlider;
    public Toggle muteChk;

    public AudioSource bgmAudio;

    // Start is called before the first frame update
    void Start()
    {
        //bgmAudio = GameObject.FindGameObjectWithTag("BgmAudio");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
        if(GamePaused == true)
        {
            if (!muteChk.isOn)
            {
                Debug.Log("NotChecked");
                
            }
            if(muteChk.isOn)
            {
                Debug.Log("Checked");
                bgmAudio.mute = !bgmAudio.mute;
            }
        }
        
    }


}
