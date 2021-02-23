using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private Scene _gameScene;

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
        SceneManager.LoadScene("GameScene");

        PlayerMovement.death = false;

    }

    public void GotoStartScene()
    {
        SceneManager.LoadScene("Start");
    }

    public void ReloadGameScene()
    {
        //Application.LoadLevel(_gameScene.name);
    }
}