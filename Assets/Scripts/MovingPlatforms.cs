using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{ 


    //  Variables //

    public GameObject Player;// Set the soldier as a GameObject 

    private float currentPos;// Set current pos of the moving plats
    private bool _onLimit;// Check if on the limits
    private float zLimit = 27.6f;// Set the zlimit for the moving plat
    private float speed = 4f;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        PlatMove();// Call the Plat2Move Function
    }

    // PlatMove Function
    private void PlatMove()
    {
        currentPos = transform.position.z;

        if (currentPos < zLimit && _onLimit)// Check if the current pos if lesser than the limit 
        {
            MoveForward();// Call moveForward Function that will move forward
        }
        else if (currentPos > 12.91 && !_onLimit)
        {
            MoveBackward();// Call moveBackward Function that will move backwards
        }
        else
        {
            _onLimit = !_onLimit;
        }
    }

    // MoveForward Function
    private void MoveForward()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    // MoveBackward Function
    private void MoveBackward()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * -speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if colliding with the Player
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.collider.transform.SetParent(transform);// Set the player gameObject to a child of the moving platform
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        collision.collider.transform.SetParent(null);// On Exit will remove player from child and will be back to normal
    }
}