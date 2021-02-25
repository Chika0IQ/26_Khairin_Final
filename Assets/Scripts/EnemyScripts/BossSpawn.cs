using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawn : MonoBehaviour
{
    public GameObject bossPrefab; // Set the bossPrefab as a GameObject
    public GameObject bossHealthUI; // Set the bossHealthUI as a Gameobject

    // Start is called before the first frame update
    void Start()
    {
        BossScript.bossFollow = false; // Set the bool of bossFollow in BossScript to false

        bossHealthUI.SetActive(false); // Setting the bossHealthUI to false/Not Visible

        Instantiate(bossPrefab); // Spawning the bossPrefab when game starts
    }

    // Update is called once per frame
    void Update()
    {

        // Check if the bossFollow bool is true
        if(BossScript.bossFollow == true)
        {
            bossHealthUI.SetActive(true); // If so, set the bossHealthUI to true/visible
        }
    }
}