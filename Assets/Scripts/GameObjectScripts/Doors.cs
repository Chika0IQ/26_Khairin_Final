using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{

    private float speed = 1f;

    public static bool btnBool = false;
    private bool _leftlimit = false;
    private bool _rightlimit = false;
    public GameObject _leftDoor;
    public GameObject _rightDoor;

    public GameObject button;
 

    // Start is called before the first frame update
    void Start()
    {
        _leftlimit = false;
        _rightlimit = false;
        button.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
   
    public void Move()
    {
        FirstMoveDoor();
    }

    private void FirstMoveDoor()
    {
        if (btnBool == true)
        {
            RightMove();
            LeftMove();
        }
        if (_leftlimit && _rightlimit)
        {
            StartCoroutine(btnDestroy());
        }
    }

   

    private void LeftMove()
    {
        if (_leftDoor.transform.position.x > -6.2)
        {
            _leftDoor.transform.Translate(Vector3.right * speed * Time.deltaTime);
            _leftlimit = true;
        }
    }

    private void RightMove()
    {
        if (_rightDoor.transform.position.x < 5.576f)
        {
            _rightDoor.transform.Translate(Vector3.right * Time.deltaTime * speed);
            _rightlimit = true;
        }
    }

    
    public IEnumerator btnDestroy()
    {
        LeftMove();
        RightMove();

        yield return new WaitForSeconds(2f);

        btnBool = false;

        button.SetActive(false);
    }
}