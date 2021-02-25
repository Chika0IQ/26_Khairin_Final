using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{

    public float spinSpeed;// Set the spinSpeed of the coin

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(spinSpeed * Time.deltaTime, 0, 0));// Rotate the coin when spawned
    }

    private void OnTriggerEnter(Collider other)
    {
        // Checks if colliding with the player
        if(other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);// Destory the coin if colliding 
            PlayerMovement._coinCollected += 1;// Add 1 to the coinCollected in the playerMovement
        }
    }
}
