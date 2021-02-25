using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUIScript : MonoBehaviour
{

    //Variables//

    public GameObject _coinsTxt; // Setting the CoinsTxt to GameObject so it can be reference later on
    public GameObject _shopMenuUI; // Settin the ShopUIMenu to GameObject so it can be set to Active or not in the script (Depends on player input)
    public PlayerMovement playerScript; // Referencing the PlayerMovement script
    public AudioClip[] audioClipArr; // Setting the AudioClip array
    private AudioSource audioSource; // Setting the AudioSource variable

    public static bool shopPaused = false; // Made a static shopPaused bool to be reference in other scripts 

    // Start is called before the first frame update
    void Start()
    {

        audioSource = GetComponent<AudioSource>(); // Getting the AudioSource Component

        _coinsTxt = GameObject.FindWithTag("coinsTxt"); // Finding the tag for coinTxt as it can't be dragged on the prefab

        CoinsCollected(); // Calling CoinCollected Function

        _shopMenuUI.SetActive(false); // Setting the ShopUIMenu to false on start so it wont be display at start until conditions met
    }

    // Update is called once per frame
    void Update()
    {
        CoinsCollected();// Calling CoinCollected Function

        //Getting User input for "B"
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (shopPaused == true) // Check if the variable for shopPaused if true
            {
                Resume(); // If so, call Resume Function
            }
            else if (PauseMenuScript.GamePaused == false) // Else check if PauseMenuScript GamePaused is false
            {
                Pause(); // If so, will call Pause Function
            }
        }
    }

    public void Resume()// Do Nothing and set game to normal unless game was paused before
    {
        _shopMenuUI.SetActive(false);
        Time.timeScale = 1f;
        shopPaused = false;
        CoinsCollected();
    }

    public void Pause()//Pause Game and setting the values
    {
        audioSource.PlayOneShot(audioClipArr[0], 0.2f);
        _shopMenuUI.SetActive(true);
        Time.timeScale = 0f;
        shopPaused = true;
        CoinsCollected();
    }

    public void CoinsCollected() //CoinCollected Function to display the current ammount of PlayerCoins achieved
    {
        _coinsTxt.GetComponent<Text>().text = "Coins Collected: " + PlayerMovement._coinCollected;
    }
}