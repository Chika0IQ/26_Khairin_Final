using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors2 : MonoBehaviour
{

    private float speed = 1f;

    public GameObject button2;

    public static bool btnBool2 = false;
    private bool _leftlimit2 = false;
    private bool _rightlimit2 = false;
    public GameObject _leftDoor2;
    public GameObject _rightDoor2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SecondMoveDoor();
    }

    private void SecondMoveDoor()
    {
        if (btnBool2 == true)
        {
            LeftMove2();
            RightMove2();
        }
        if (_leftlimit2 && _rightlimit2)
        {
            StartCoroutine(btnDestroy2());
        }
    }

    private void LeftMove2()
    {
        if (_leftDoor2.transform.position.x > -6.2)
        {
            _leftDoor2.transform.Translate(Vector3.right * speed * Time.deltaTime);
            _leftlimit2 = true;
        }
    }

    private void RightMove2()
    {
        if (_rightDoor2.transform.position.x < 6.23f)
        {
            _rightDoor2.transform.Translate(Vector3.right * Time.deltaTime * speed);
            _rightlimit2 = true;
        }
    }
    public IEnumerator btnDestroy2()
    {
        yield return new WaitForSeconds(2f);
        Destroy(button2);
    }
}
