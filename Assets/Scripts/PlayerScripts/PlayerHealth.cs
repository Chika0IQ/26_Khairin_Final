using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public static float health; // Set the health variable of the player 
    public static float maxHealth = 100;// Set the max health of the player to 100

    public GameObject playerhealthTxt;// Set the the playerHealthTxt as a GameObject
    public GameObject healthBar;// Set the health bar as a GameObject
    public Slider slider;// Set the slider for the player heatlh

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        slider.value = CalHealth();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = CalHealth();

        if (health < maxHealth)
        {
            healthBar.SetActive(true);
        }
        
        if (health > maxHealth)
        {
            health = maxHealth;
        }

        playerhealthTxt.GetComponent<Text>().text = "Health: " + health;
    }

    // Calhealth Function
    private float CalHealth()
    {
        return health / maxHealth;
    }
}
