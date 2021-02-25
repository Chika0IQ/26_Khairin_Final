using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthScript : MonoBehaviour
{
    public Slider slider; // Setting the variable for the slider/boss Health UI as a slider so it will go down as the health decreases
    public GameObject bosshealthBar; // Setting the healthBarUI as a GameObject
    public GameObject bosshealthTxt; // Setting the bossHealthTxt as a GameOjeect
    public GameObject bossHealthUI; // Setting the bossHealth Canvas UI as a GameObject
    public BossScript _bossScript; // Setting the BossScript as a variable so it will be easier to call later on whem coding

    private float bossHealth; // A float variable for the bossHealth
    private float bossMaxHealth; // A float variable for the MaxBossHealth

    // Start is called before the first frame update
    void Start()
    {
        BossScript.bossFollow = false; // Call the Follow variable from the BossScript and set it to false on start
        bossHealthUI.SetActive(false); // Setting the BossHealth Canvas to false/invisible/diasbled at start
        BossScript._bossHealth = BossScript._bossMaxHealth; // bossHealth is = to MaxBossHealth
        slider.value = CalHealth(); // Set the slidervalue to the CalHealth Function
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = CalHealth(); // Set the slidervalue to the CalHealth Function

        bossHealth = BossScript._bossHealth; // Setting the variable BossScript._bossHealth to bossHealth as it will be easier and less of a nuisance to can it anytime
        bossMaxHealth = BossScript._bossMaxHealth; // Setting the variable BossScript._bossMaxHealth to bossMaxHealth so it will make it easier to call as compared to typing the whole string again



        if (bossHealth < bossMaxHealth)
        {
            bosshealthBar.SetActive(true);
        }

        if (bossHealth > bossMaxHealth)
        {
            bossHealth = bossMaxHealth;
        }

        if(BossScript._bossHealth <= 0) // If Boss Health is lesser or equal to 0,
        {
            BossScript.bossDeath = true; // set the bossDeath bool to true
        }

        if(BossScript.bossDeath == false)
        {
            bosshealthTxt.GetComponent<Text>().text = "Boss Health: " + bossHealth;
        }
        else if (BossScript.bossDeath == true)
        {
            bossHealthUI.SetActive(false);
        }

    }


    // CalHealth Function to return bossHealth to be divided by MaxBossHealth
    private float CalHealth()
    {
        return BossScript._bossHealth / BossScript._bossMaxHealth;
    }
}