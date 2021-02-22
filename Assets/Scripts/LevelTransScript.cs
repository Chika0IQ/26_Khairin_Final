using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelTransScript : MonoBehaviour
{

    public Animator gameTrans;

    private int levelToLoad;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerMovement.death == true)
        {
            FadeToLevel(2);
        }

        if(EnemyScript.zombsKilled == 10)
        {
            //FadeToLevel(3);
        }
    }

   public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        gameTrans.SetTrigger("FadeOUT");
    }

    public void OnFadeComp()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}