using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{


    private float speed = 3f;
    private float xlimit;
    private float currentPos;
    private float _limit;


    public GameObject _leftDoor;
    public GameObject _rightDoor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if(Input.GetKey(KeyCode.L))
        {
            Move();
        }
    }

    private void Move()
    {
        _rightDoor.transform.Translate(Vector3.right * speed * Time.deltaTime);
        _leftDoor.transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void MoveLeft()
    {
        
    }
}
