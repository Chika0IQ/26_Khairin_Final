using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{

    public GameObject _MovePlat2;
    public GameObject _MovePlat3;
    public GameObject Player;

    private float currentPos;
    private bool _onLimit;
    private float zLimit = 27.6f;
    private float speed = 4f;

    

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Plat2Move();
    }

    private void Plat2Move()
    {
        currentPos = transform.position.z;

        if (currentPos < zLimit && _onLimit)
        {
            MoveForward();
        }
        else if (currentPos > 12.91 && !_onLimit)
        {
            MoveBackward();
        }
        else
        {
            _onLimit = !_onLimit;
        }
    }

    private void MoveForward()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private void MoveBackward()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * -speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.collider.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        collision.collider.transform.SetParent(null);
    }
}