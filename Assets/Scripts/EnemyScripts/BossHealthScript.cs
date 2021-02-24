using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthScript : MonoBehaviour
{

    public GameObject bosshealthBar;
    public Slider slider;

    public GameObject bosshealthTxt;
    public GameObject bossHealthUI;
    public BossScript _bossScript;

    private float bossHealth;
    private float bossMaxHealth;

    // Start is called before the first frame update
    void Start()
    {
        BossScript.bossFollow = false;
        bossHealthUI.SetActive(false);
        BossScript._bossHealth = BossScript._bossMaxHealth;
        slider.value = CalHealth();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = CalHealth();

        bossHealth = BossScript._bossHealth;
        bossMaxHealth = BossScript._bossMaxHealth;

        if (bossHealth < bossMaxHealth)
        {
            bosshealthBar.SetActive(true);
        }

        if (bossHealth > bossMaxHealth)
        {
            bossHealth = bossMaxHealth;
        }

        if(BossScript._bossHealth <= 0)
        {
            BossScript.bossDeath = true;
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

    private float CalHealth()
    {
        return BossScript._bossHealth / BossScript._bossMaxHealth;
    }
}