using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawn : MonoBehaviour
{
    public GameObject bossPrefab;
    public GameObject bossHealthUI;

    //private static bool nxtSpawn = false;


    // Start is called before the first frame update
    void Start()
    {
        BossScript.bossFollow = false;

        bossHealthUI.SetActive(false);
        Instantiate(bossPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        if(BossScript.bossFollow == true)
        {
            bossHealthUI.SetActive(true);
        }
    }
}