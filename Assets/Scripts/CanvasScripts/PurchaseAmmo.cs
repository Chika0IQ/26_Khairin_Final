using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseAmmo : MonoBehaviour
{

    public static bool addedAmmo = false;

    private AudioSource audioSource;
    public AudioClip[] coinClipsArr;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PurchseAmmo()
    {
        if (PlayerMovement._coinCollected >= 3 && PlayerMovement.ammoCount <= 0)
        {

            audioSource.PlayOneShot(coinClipsArr[0], 0.3f);


            PlayerMovement.ammoCount = 20f;
            addedAmmo = true;
        }

        if(addedAmmo == true)
        {
            PlayerMovement._coinCollected -= 3;
        }
    }
}