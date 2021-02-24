using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneScript : MonoBehaviour
{

    public GameObject bckStoryCanvs;
    public GameObject instructCanvas;

    // Start is called before the first frame update
    void Start()
    {
        bckStoryCanvs.SetActive(false);
        instructCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GotoGameScene()
    {
        SceneManager.LoadScene("GameScene");

        PlayerMovement.death = false;

    }

    public void GotoStartScene()
    {
        SceneManager.LoadScene("Start");
    }

    public void BackStory()
    {
        bckStoryCanvs.SetActive(true);

    }

    public void Instruct()
    {
        instructCanvas.SetActive(true);

    }

    public void ExtBack()
    {
        bckStoryCanvs.SetActive(false);
    }

    public void ExtInstruct()
    {
        instructCanvas.SetActive(false);
    }
}