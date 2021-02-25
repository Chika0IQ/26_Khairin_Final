using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneScript : MonoBehaviour
{

    public GameObject bckStoryCanvs; // Set the backStory canvas as a GameObject so it can be set to Active or not
    public GameObject instructCanvas; // Set the instuction Canvas as a GameObject so it can set to Active or not (Visible or not)

    // Start is called before the first frame update
    void Start()
    {
        bckStoryCanvs.SetActive(false); // Setting BackStory Canvas to NotActive on Start
        instructCanvas.SetActive(false); // Setting BackStory Canvas to Not Active on Start until conditions met
    }

    // Update is called once per frame
    void Update()
    {

    }


    // Go to the Game Scene Function to be called on the Button pressed
    public void GotoGameScene()
    {
        SceneManager.LoadScene("GameScene");// Load the "GameScene"

        PlayerMovement.death = false; // Set death in PlayerMovement script to false

    }

    // Go to the Start Scene Function if the button in pressed
    public void GotoStartScene()
    {
        SceneManager.LoadScene("Start"); // Load "Start" Scene
    }

    // Setting the BackStory Canvas to be True/Visible in the game
    public void BackStory()
    {
        bckStoryCanvs.SetActive(true);

    }

    // Setting the Instruction Canvas to be True/Visibile in the game if function is called
    public void Instruct()
    {
        instructCanvas.SetActive(true);

    }

    // Will set the BackStory canvas to false/invisible if function in called
    public void ExtBack()
    {
        bckStoryCanvs.SetActive(false);
    }

    // Set the Instruction Canvas to false/invisible if function is called
    public void ExtInstruct()
    {
        instructCanvas.SetActive(false);
    }
}