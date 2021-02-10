using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float rotateSpeed = 950f;
    [SerializeField] private float verticalRotate = 80f;
    [SerializeField] private float jump = 7.5f;



    public Rigidbody playerRb;
    //public Animator animator;
    public Camera cam1;
    public Camera cam2;


    private int spacePressed = 0;
    public float range = 100f;

    private float gravity = 850f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerControls();
    }

    private void PlayerControls()
    {
        playerRb.AddForce(Vector3.down * Time.deltaTime * gravity);

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0, Time.deltaTime * -rotateSpeed, 0));
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0, Time.deltaTime * rotateSpeed, 0));
        }

        if (Input.GetKeyDown(KeyCode.Space) && spacePressed < 1) 
        {
            playerRb.AddForce(Vector3.up * jump, ForceMode.Impulse);
            spacePressed += 1;
            Debug.Log(spacePressed);
        }
    }

    private void PlayerShoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam1.transform.position, cam1.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
        }
    }
}
