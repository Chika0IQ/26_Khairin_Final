using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUIScript : MonoBehaviour
{

    public GameObject _coinsTxt;
    public GameObject _shopMenuUI;

    public PlayerMovement playerScript;

    public static bool shopPaused = false;



    // Start is called before the first frame update
    void Start()
    {
        _coinsTxt = GameObject.FindWithTag("coinsTxt");

        CoinsCollected();

        _shopMenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        //_coinsTxt = GameObject.FindWithTag("coinsTxt");
        CoinsCollected();
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (shopPaused == true)
            {
                Resume();
            }
            else if (PauseMenuScript.GamePaused == false)
            {
                Pause();
            }
        }
    }

    public void Resume()// Do Nothing
    {
        _shopMenuUI.SetActive(false);
        Time.timeScale = 1f;
        shopPaused = false;
        CoinsCollected();
    }

    public void Pause()//Pause Game
    {
        _shopMenuUI.SetActive(true);
        Time.timeScale = 0f;
        shopPaused = true;
        CoinsCollected();
    }

    public void CoinsCollected()
    {
        _coinsTxt.GetComponent<Text>().text = "Coins Collected: " + PlayerMovement._coinCollected;
    }
}