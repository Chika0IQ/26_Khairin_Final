using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoScripts : MonoBehaviour
{


    public GameObject ammoTxt;// Set the ammoTxt as a GameObject

    //public PlayerMovement ammo;



    // Start is called before the first frame update
    void Start()
    {
        //ammoTxt.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        // Set the ammoTxt with reference from PlayerMovement ammoCount
        ammoTxt.GetComponent<Text>().text = "Ammo: " + PlayerMovement.ammoCount;
    }
}
