using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{

    public static float health;
    public static float maxHealth = 100;

    public GameObject healthBar;
    public Slider slider;



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
        
        if(health < maxHealth)
        {
            healthBar.SetActive(true);
        }

        if(health <= 0)
        {
            Destroy(gameObject);
        }

        if(health > maxHealth)
        {
            health = maxHealth;
        }
    }

    private float CalHealth()
    {
        return health / maxHealth;
    }

    
}
