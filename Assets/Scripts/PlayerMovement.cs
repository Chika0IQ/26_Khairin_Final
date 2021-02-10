using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float rotateSpeed = 950f;
    [SerializeField] private float jump = 7.5f;



    public Rigidbody playerRb;
    public Animator animator;
    public GameObject cam1;
    public GameObject cam2;
    public GameObject bulletPrefab;
    public GameObject bulletSpawn;


    public static int spacePressed = 0;
    public static float ammoCount = 15f;
    public float range = 100f;

    private float gravity = 850f;
    private int tPressed = 0;


    // Start is called before the first frame update
    void Start()
    {
        cam1.SetActive(true);
        cam2.SetActive(false);

        animator.SetBool("isIdle", true);
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

            animator.SetBool("isIdle", false);
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            animator.SetBool("isIdle", true);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0, Time.deltaTime * -rotateSpeed, 0));
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
            animator.SetBool("isIdle", false);
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            animator.SetBool("isIdle", true);
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

        if (Input.GetKeyDown(KeyCode.T))
        {
            if (tPressed == 0)
            {
                CameraChange1();
            }
            else if (tPressed == 1)
            {
                CameraChange2();
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            animator.SetTrigger("shooting");

            PlayerShoot();

            ammoCount -= 1;
        }
        else if (Input.GetKeyUp(KeyCode.Q))
        {
            animator.SetBool("isIdle", true);
        }

        if(ammoCount <= 0)
        {

        }
    }

    private void CameraChange1()
    {
        cam1.SetActive(true);
        cam2.SetActive(false);

        tPressed = 1;
    }

    private void CameraChange2()
    {
        cam1.SetActive(false);
        cam2.SetActive(true);

        tPressed = 0;
    }

    private void PlayerShoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam1.transform.position, cam1.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Instantiate(bulletPrefab, bulletSpawn.transform.position, transform.rotation);
        }
    }
}