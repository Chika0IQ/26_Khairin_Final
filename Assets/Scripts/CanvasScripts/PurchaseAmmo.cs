using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseAmmo : MonoBehaviour
{

    public static bool addedAmmo = false;// Make a static addedAmmo bool to be call in other scripts

    private AudioSource audioSource; // Instialise the AudioSource component
    public AudioClip[] coinClipsArr; // Getting the AudioClip variable and array for more audio Files to be added and called easly


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Getting the Audio Source Component on Start
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //Purchase Ammo Function to be put on the PurchaseAmmo Button that will deduct the coins collected and increase the Ammo count to a max of 20
    public void PurchseAmmo()
    {
        if (PlayerMovement._coinCollected >= 3 && PlayerMovement.ammoCount <= 0) 
        {

            audioSource.PlayOneShot(coinClipsArr[0], 0.3f); // Play audio in Array with volume specifically set 


            PlayerMovement.ammoCount = 20f; // Call the ammoCount from PlayerMovement script and set the value to 20
            addedAmmo = true; // Change bool addedAmmo to true
        }

        // Check if the bool for addedAmmo is true, will then deduct 3 coinsCollected from PlayerMovement Script
        if(addedAmmo == true)
        {
            PlayerMovement._coinCollected -= 3; // Call _coinCollected variable from PlayerMovement Script
        }
    }
}