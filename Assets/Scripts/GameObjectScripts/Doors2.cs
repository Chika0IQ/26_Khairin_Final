using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors2 : MonoBehaviour
{
    //Variables//

    public GameObject _leftDoor2;// Set the leftdoor of level 2 as a GameObject
    public GameObject _rightDoor2;// Set the rightdoor of level 2 as a GameObject
    public GameObject button2;// Set the button of level 2 as a GameObject

    public static bool btnBool2 = false;// Set a Static bool for the button2 to be called in other scripts when necessary
    private bool _leftlimit2 = false;// Set bool of the limit of the left door of level 2
    private bool _rightlimit2 = false;// Set bool of the limit of the right door of level 2
    private float speed = 1f;// Set the speed of the doors in the 2nd level

    // Start is called before the first frame update
    void Start()
    {
        _leftlimit2 = false; // Set the bool of the left door2 to false on start
        _rightlimit2 = false;// Set the bool of the right door2 to false on start
        button2.SetActive(true);// Set the button GameObject to true/Visible on start
    }

    // Update is called once per frame
    void Update()
    {
        // Call the Second Move Door Function
        SecondMoveDoor();
    }

    private void SecondMoveDoor()
    {

        // Check if the button2 bool if true
        if (btnBool2 == true)
        {
            LeftMove2();
            RightMove2();
        }

        // Check if left and right limit bools are true
        if (_leftlimit2 && _rightlimit2)
        {
            StartCoroutine(btnDestroy2());// Will call the btnDestroy2 Coroutine
        }
    }

    // Left Move2 Function
    private void LeftMove2()
    {
        // Check if leftdoor2 current position is more then -6.2f
        if (_leftDoor2.transform.position.x > -6.2)
        {
            // Will move the leftdoor2 towards the limit if not reached yet
            _leftDoor2.transform.Translate(Vector3.right * speed * Time.deltaTime);
            _leftlimit2 = true;
        }
    }

    // Left Move2 Function
    private void RightMove2()
    {
        // Check if rightdoor2 current position is lesser then 6.23f
        if (_rightDoor2.transform.position.x < 6.23f)
        {
            // Will move the rightdoor towards the limit if not reached yet
            _rightDoor2.transform.Translate(Vector3.right * Time.deltaTime * speed);
            _rightlimit2 = true;
        }
    }

    // Btn2 Destroy Coroutine
    public IEnumerator btnDestroy2()
    {
        LeftMove2();
        RightMove2();

        yield return new WaitForSeconds(2f);

        btnBool2 = false;

        button2.SetActive(false);
    }
}
