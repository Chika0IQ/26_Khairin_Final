using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTeleport: MonoBehaviour
{

    private float speed = 1f;

    public GameObject _leftDoor3;
    public GameObject _rightDoor3;

    public GameObject camTeleport;

    private bool endFin = false;

    // Start is called before the first frame update
    void Start()
    {
        camTeleport.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        TeleportMoveDoor();
    }

    private void TeleportMoveDoor()
    {
        if (BossScript.bossDeath == true && endFin == false)
        {
            StartCoroutine(ending());
        }
    }

    private void LeftMove3()
    {
        if (_leftDoor3.transform.position.x > -6.2)
        {
            _leftDoor3.transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }

    private void RightMove3()
    {
        if (_rightDoor3.transform.position.x != 4f)
        {
            _rightDoor3.transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }
    public IEnumerator ending()
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
