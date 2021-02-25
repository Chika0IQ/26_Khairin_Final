using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTeleport: MonoBehaviour
{

    public GameObject _leftDoor3;// Set the leftdoor of level 3 as a GameObject
    public GameObject _rightDoor3;// Set the rightdoor of level 3 as a GameObject
    public GameObject camTeleport;// Set the teleporter camera as a GameObject

    private bool endFin = false;// Check if the Door has finished opening
    private float speed = 1f;// Set the speed of the doors for the teleporter

    // Start is called before the first frame update
    void Start()
    {
        camTeleport.SetActive(false); // Set the teleporter camera to true/Visible on start 
    }

    // Update is called once per frame
    void Update()
    {
        TeleportMoveDoor();// Call the Teleport Move Door Function
    }

    // Teleport Move Door Function
    private void TeleportMoveDoor()
    {

        // Check if the bossDeath is true and endFin bool are false 
        if (BossScript.bossDeath == true && endFin == false)
        {
            StartCoroutine(ending()); // Call the Ending Coroutine
        }
    }

    // Left Move3 Function
    private void LeftMove3()
    {
        // Check if leftdoor3 current position is more then -6.2f
        if (_leftDoor3.transform.position.x > -6.2)
        {
            // Will move the leftdoor3 towards the limit if not reached yet
            _leftDoor3.transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }

    // Left Move3 Function
    private void RightMove3()
    {
        // Check if leftdoor3 current position is not equal to 4f
        if (_rightDoor3.transform.position.x != 4f)
        {
            // Will move the rightdoor3 towards the limit if not reached yet
            _rightDoor3.transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }
    
    // Ending Coroutine
    public IEnumerator ending()
    {
        if(endFin == false)
        {
            yield return new WaitForSeconds(1.5f);

            camTeleport.SetActive(true);

            LeftMove3();

            RightMove3();

            yield return new WaitForSeconds(5f);

            camTeleport.SetActive(false);

            //Destroy(camTeleport);

            endFin = true;
        }
       
    }
}
