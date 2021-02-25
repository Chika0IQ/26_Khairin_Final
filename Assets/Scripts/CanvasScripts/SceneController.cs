using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GotoGameScene()
    {
        SceneManager.LoadScene("GameScene"); // Change current scene and load "GameScene" if button pressed or conditions met

        PlayerMovement.death = false; // Set the variable death in PlayerMovement to false at start to restart all values under Death

    }

    public void GotoStartScene()
    {
        SceneManager.LoadScene("Start"); // Change current scene and load "Start" scene
    }
}