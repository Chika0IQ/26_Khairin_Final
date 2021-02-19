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
    //public GameObject healthTxt;


    public static int spacePressed = 0;
    public static float ammoCount = 15f;
    public float range = 100f;

    private float gravity = 850f;
    private int tPressed = 0;
    private bool isReloading = false;
    private bool death = false;

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
        if(death == false)
        {
            PlayerControls();
        }
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




        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

            animator.SetBool("isWalkLeft", true);
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("isWalkLeft", false);
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



        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            animator.SetBool("isWalkRight", true);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("isWalkRight", false);
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

        if (ammoCount <= 15 & ammoCount != 0 & isReloading == false)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                animator.SetTrigger("triggShooting");

                PlayerShoot();

                ammoCount -= 1;
            }
            else if (Input.GetKeyUp(KeyCode.Q))
            {
                //animator.SetBool("triggShooting", true);
            }
        }
        else if (isReloading == true)
        {
            isReloading = false;
        }

        if(ammoCount <= 0)
        {
            if(Input.GetKey(KeyCode.R))
            {
                animator.SetTrigger("triggReloading");

                ammoCount += 15f;

                isReloading = true;
            }
            else if (Input.GetKeyUp(KeyCode.R))
            {

                animator.SetTrigger("isIdle");

                //isReloading = false;
            }
        }

        if(PlayerHealth.health == 0)
        {
            animator.SetTrigger("triggDeath");
            

            death = true;

            GameObject.FindGameObjectsWithTag("Enemy");
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
            //Debug.Log(hit.transform.name);
            Instantiate(bulletPrefab, bulletSpawn.transform.position, transform.rotation);
        } 
    }
}