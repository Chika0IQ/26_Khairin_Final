using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingOrbScript : MonoBehaviour
{

    private float spinSpeed = 50f; // Set spinSpeed of the Healing Orb

    public AnimationCurve myCurve; // Set Vertical animation of the healing orb

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, spinSpeed * Time.deltaTime, 0)); // Rotate the healing Orb
        transform.position = new Vector3(transform.position.x, myCurve.Evaluate((Time.time % myCurve.length)), transform.position.z);// Change the vertical motion of the healing orb
    }

    private void OnTriggerEnter(Collider other)
    {
        // Checks if is colliding with the player
        if(other.gameObject.CompareTag("Player"))
        {
            PlayerHealth.health = 100;// Set Player health to 100
        }
    }
}