using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{

    //Variables//

    public static bool btnBool = false;// Set a Static bool for the button to be called in other scripts when necessary
    private float speed = 1f;// Set the speed of the doors
    private bool _leftlimit = false; // Set bool of the limit of the left door
    private bool _rightlimit = false;// Set bool of the limit of the right door

    public GameObject _leftDoor; // Set the leftdoor as a GameObject
    public GameObject _rightDoor; // Set the rightdoor as a GameObject
    public GameObject button; // Set the button as a GameObject
 
    // Start is called before the first frame update
    void Start()
    {
        _leftlimit = false; // Set the bool of the left door to false on start
        _rightlimit = false; // Set the bool of the right door to false on start
        button.SetActive(true); // Set the button GameObject to true/Visible on start
    }

    // Update is called once per frame
    void Update()
    {
        Move();//Call the Move Function on update
    }
   
    // Move Function
    public void Move()
    {
        FirstMoveDoor();
    }

    // First Move Door Function
    private void FirstMoveDoor()
    {
        // Check if the button bool if true
        if (btnBool == true)
        {
            RightMove();
            LeftMove();
        }

        // Check if left and right limit bools are true
        if (_leftlimit && _rightlimit)
        {
            StartCoroutine(btnDestroy());// Will call the btnDestroy Coroutine
        }
    }

   
    // Left Move Function
    private void LeftMove()
    {
        // Check if leftdoor current position is more then -6.4f
        if (_leftDoor.transform.position.x > -6.2)
        {
            // Will move the leftdoor towards the limit if not reached yet
            _leftDoor.transform.Translate(Vector3.right * speed * Time.deltaTime);
            _leftlimit = true;
        }
    }

    // Right Move Function
    private void RightMove()
    {
        // Check if the rightdoor's current position is lesser than 5.576f
        if (_rightDoor.transform.position.x < 5.576f)
        {
            // Will move towards the right limit if not reached yet
            _rightDoor.transform.Translate(Vector3.right * Time.deltaTime * speed);
            _rightlimit = true;
        }
    }

    // Btn Destroy Coroutine
    public IEnumerator btnDestroy()
    {
        LeftMove();
        RightMove();

        yield return new WaitForSeconds(2f);

        btnBool = false;

        button.SetActive(false);
    }
}