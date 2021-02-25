using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{


    public GameObject Player;// Get the Player Prefab as a GameObject
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Player);// Instatiate the Player on start
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
