using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseAmmo : MonoBehaviour
{

    public static bool addedAmmo = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PurchseAmmo()
    {
        if (PlayerMovement._coinCollected >= 3 && PlayerMovement.ammoCount <= 0)
        {
            PlayerMovement.ammoCount = 20f;
            addedAmmo = true;
        }

        if(addedAmmo == true)
        {
            PlayerMovement._coinCollected -= 3;
        }
    }
}