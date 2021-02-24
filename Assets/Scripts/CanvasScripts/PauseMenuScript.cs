using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuScript : MonoBehaviour
{

    public static bool GamePaused = false;
    private bool isMuted;

    public GameObject pauseMenuUI;
    public Slider volSlider;
    public Toggle muteChk;

    public AudioSource bgmAudio;

    // Start is called before the first frame update
    void Start()
    {
        //bgmAudio = GameObject.FindGameObjectWithTag("BgmAudio;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused)
            {
                Resume();
            }
            else if (ShopUIScript.shopPaused == false)
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
    }

    public void BgmMute()
    {
        isMuted = !isMuted;
        AudioListener.pause = isMuted;
    }

    public void SetVol(float vol)
    {
        AudioListener.volume = vol;
    }
}