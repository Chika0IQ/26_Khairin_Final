using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public static float health;
    public static float maxHealth = 100;

    public GameObject healthBar;
    public Slider slider;

    public GameObject playerhealthTxt;


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

        if (health <= 0)
        {
            //PlayerMovement.animator.SetBool("isDeath", true);
        }

        if (health > maxHealth)
        {
            health = maxHealth;
        }

        playerhealthTxt.GetComponent<Text>().text = "Health: " + health;
    }

    private float CalHealth()
    {
        return health / maxHealth;
    }
}
