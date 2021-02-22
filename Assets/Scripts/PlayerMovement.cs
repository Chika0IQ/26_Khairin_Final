using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float jump = 7.5f;

    private AudioSource audioSource;

    public GameObject playerPrefab;
    public Rigidbody playerRb;
    public Animator animator;
    public GameObject cam1;
    public GameObject cam2;
    public GameObject cam3;
    public GameObject bulletPrefab;
    public GameObject bulletSpawn;
    public GameObject ZombsKilledTxt;
    public AudioClip[] PlayerAudioClipArr;
    public Light FleshLight;

    public static int spacePressed = 0;
    public static float ammoCount = 20f;
    public static float rotateSpeed = 1000f;
    public static bool death = false;
    public static int _coinCollected = 0;

    public float range = 100f;

    private float gravity = 850f;
    private int tPressed = 0;
    private bool isReloading = false;
    private bool stopControls = false;
    private bool fleshOn = false;
    

    public PauseMenuScript _pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        rotateSpeed = 1000f;

        cam1.SetActive(true);
        cam2.SetActive(false);
        cam3.SetActive(false);

        animator.SetBool("isIdle", true);

        playerRb = GetComponent<Rigidbody>();

        audioSource = GetComponent<AudioSource>();

        animator = GetComponent<Animator>();

        _pauseMenu = FindObjectOfType<PauseMenuScript>();

        ZombsKilledTxt = GameObject.FindWithTag("ZombsKilledTxt");

        death = false;

        stopControls = false;

        EnemyScript.zombsKilled = 0;

        _coinCollected = 0;

        ammoCount = 20f;
    }

    // Update is called once per frame
    void Update()
    {
        if(stopControls == false)
        {
            PlayerControls();
        }

        ZombsKilledTxt.GetComponent<Text>().text = "Zombie Killed: " + EnemyScript.zombsKilled;

        PlayerRaycast();
    }

    private void PlayerControls()
    {

        if (Input.GetKeyDown(KeyCode.I))
        {
            EnemyScript.zombsKilled += 1;
        }

        if (Input.GetKey(KeyCode.P))
        {
            PlayerHealth.health = 0;
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            _coinCollected += 5;
            EnemyScript.zombsKilled += 10;
        }

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

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0, Time.deltaTime * -rotateSpeed, 0));
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

        if(Input.GetKeyDown(KeyCode.C) && fleshOn == true)
        { 
            FleshLight.enabled = true;
        }
        else if (Input.GetKeyDown(KeyCode.C) && fleshOn == false)
        {
            FleshLight.enabled = false;
        }
        else
        {
            fleshOn = !fleshOn;
        }

        if (ammoCount <= 20 & ammoCount != 0 & isReloading == false)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                animator.SetTrigger("triggShooting");

                audioSource.PlayOneShot(PlayerAudioClipArr[0], 0.2f);

                PlayerShoot();

                ammoCount -= 1;
            }
            else if (Input.GetKeyUp(KeyCode.Q))
            {

            }
        }
        else if (isReloading == true)
        {
            isReloading = false;
        }

        if(PlayerHealth.health == 0)
        {
            EnemyScript.zomFollow = false;

            animator.SetTrigger("triggDeath");

            StartCoroutine(playerDeath());
        }

        if (PurchaseAmmo.addedAmmo == true)
        {
            animator.SetTrigger("triggReloading");

            isReloading = true;

            audioSource.PlayOneShot(PlayerAudioClipArr[1], 0.2f);

            PurchaseAmmo.addedAmmo = false;
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

    private void CameraChange3()
    {
        cam1.SetActive(false);
        cam2.SetActive(false);
        cam3.SetActive(true);

        tPressed = 0;
    }

    private void PlayerShoot()
    {
        Instantiate(bulletPrefab, bulletSpawn.transform.position, transform.rotation);
    }

    private void PlayerRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam1.transform.position, cam1.transform.forward, out hit, range))
        { 
            if (hit.collider.tag == "Button" && EnemyScript.zombsKilled >= 10)
            {
                if(Input.GetKey(KeyCode.F))
                {
                    Doors.btnBool = true;
                }
            }
            if (hit.collider.tag == "Button2")
            {
                if(Input.GetKey(KeyCode.F))
                {
                    Doors2.btnBool2 = true;
                }
            }
        }
    }

    public void SetSens(float _sensitivity)
    {
        rotateSpeed = _sensitivity;
    }

    private IEnumerator playerDeath()
    {
        CameraChange3();
        stopControls = true;
        yield return new WaitForSeconds(2f);
        death = true;
        yield return new WaitForSeconds(2f);
        Destroy(playerPrefab);
    }
}