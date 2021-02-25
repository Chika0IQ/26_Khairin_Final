using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    
    //----Variables----//

    public GameObject playerPrefab;// Set soldier Prefab
    public Rigidbody playerRb;// Set the rigidbody of the soldier Prefab
    public Animator animator;// Set the animator on the soldierPrefab

    // Camera GameObjects //
    public GameObject cam1;// Set the camera 1 as a GameObject
    public GameObject cam2;// Set the camera 2 as a GameObject
    public GameObject cam3;// Set the camera 3 as a GameObject

    // Bullet and Bullet Spawn GameObjects //
    public GameObject bulletPrefab;// Bullet Prefab as GameObject
    public GameObject bulletSpawn;// Bulelt SpawnPoint as GameObject

    // Zombie Killed Txt GameObject //
    public GameObject ZombsKilledTxt;// Set the ZombieKilledTxt as a GameObject

    // Audio Source Components //
    private AudioSource audioSource;// Set the AudioSource
    public AudioClip[] PlayerAudioClipArr;// Set an Array for multiple AudioFiles

    // Calling Other Scripts //
    public GameObject _lvlTransScript;// Setting the lvlTransScript
    public PauseMenuScript _pauseMenu;// Setting the pauseMenu as a gameObject

    // Enemy Spawners //
    public GameObject enemySpawner;// Set the enemySpawner1 as a GameObject
    public GameObject enemySpawner2;// Set the enemySpawner2 as a GameObject

    // BtnWarning Txt //
    public GameObject btnWarning;// Set the BtnWarning UI as a GameObject

    //Light and Particle Effects //
    public ParticleSystem muzzleFlash;// Enable the MuzzleFlash
    public Light FleshLight;// Set the light for player torch


    // Public Static Variables //
    public static float ammoCount = 20f; // Ammmo float cound variable
    public static float rotateSpeed = 1000f;// rotateSpeeed float variable
    public static bool death = false;// Death Bool of soldier
    public static int spacePressed = 0;// spacePressed int Variable
    public static int _coinCollected = 0;// coinollected Variable

    // Private Floats //
    private float moveSpeed = 5f;// Move Speed variable of player
    private float jump = 7.5f;// Jump force of player
    private float range = 100f;// Range of the raycast that is able to reach
    private float gravity = 850f;// Set the gravity of the soldier

    // Private Integers
    private int tPressed = 0;// tPRessed Variable

    // Private bools //
    private bool isReloading = false; // Reloading bool variable
    private bool stopControls = false;// stopControl bool variable
    private bool fleshOn = false;// flashLight bool variable

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;// Set the time scale to 1 on start

        rotateSpeed = 1000f;// Set rotate speed of the player back to the 1000 on start

        cam1.SetActive(true);// Set the cam1 to true/Visible on start
        cam2.SetActive(false);// Set the cam2 to false/ not Visible on start
        cam3.SetActive(false);// Set the cam3 to false/ not Visible on start

        enemySpawner.SetActive(true); // Set the lvl1 spawner to true/visible on start
        btnWarning.SetActive(false);// Set the warnning Btn to false/ not visible on start
        enemySpawner2.SetActive(true);// Set the lvl2 spawner to false/ not visible on start

        animator.SetBool("isIdle", true);// Set soldier animation to Idle to true on start

        playerRb = GetComponent<Rigidbody>();// Get the Rigidbody component from the soldier prefab
        audioSource = GetComponent<AudioSource>();// Get the audio source component from the soldier prefab
        animator = GetComponent<Animator>();// Get the Animator component from the soldier prefab
        _pauseMenu = FindObjectOfType<PauseMenuScript>();// Find the PauseMenuScript and initialise it to be reference later on


        ZombsKilledTxt = GameObject.FindWithTag("ZombsKilledTxt"); // Find the ZombieKilledTxt GameObject with the tagging
        _lvlTransScript = GameObject.FindWithTag("TransLevel");// Find the transScirpt of GameObject with the tagging
        enemySpawner = GameObject.FindWithTag("ZombSpawner");// Find the enemySpawner1 GameObject with the tagging
        enemySpawner2 = GameObject.FindWithTag("ZombSpawner2"); // Find the enemySpawner2 GameObject with the tagging

        EnemyScript.zombsKilled = 0; // Set zombies Killed variable in Enemyscript to 0 on start

        death = false;// Set the death bool to false on start
        stopControls = false;// Set the stopControls bool to false

        _coinCollected = 0;// Set coinsCollected to 0 on start
        ammoCount = 20f;// Set ammoCount to 20 at start
    }

    // Update is called once per frame
    void Update()
    {
        // Check if stopControls bool false
        if(stopControls == false)
        {
            PlayerInputs();// Call the PlayerInputs Function
        }

        ZombsKilledTxt.GetComponent<Text>().text = "Zombie Killed: " + EnemyScript.zombsKilled;// Update zombies killed text

        PlayerRaycast();// Call the PlayerRayCast Function

        // Check if the bossHealth is lesser or equal to zero
        if(BossScript._bossHealth <= 0f)
        {
            enemySpawner2.SetActive(false);// Set the zombieSpawner in lvl 2 to false to stop more zombies from spawning
        }

        // Check if soldier's y position is lesser than -1.9
        if(playerPrefab.transform.position.y < -1.9f)
        {
            SceneManager.LoadScene("LoseScene");// Change to "LoseScene"
        }

        // If player death is true
        if(death == true)
        {
            SceneManager.LoadScene("LoseScene");// Change to "LoseScene"
        }
    }

    // Player Inputs Function (All player inputs)
    private void PlayerInputs()
    {
        
        if (Input.GetKeyDown(KeyCode.H))
        {
           _coinCollected += 5;
            EnemyScript.zombsKilled += 10;
        }

        if(Input.GetKey(KeyCode.N))
        {
            BossScript._bossHealth = 0f;
            BossScript.bossDeath = true;
        }

        playerRb.AddForce(Vector3.down * Time.deltaTime * gravity);// Set the gravity of the player

        // Conditions when "W" key pressed
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);// Set the soldier forward speed
            animator.SetBool("isIdle", false);// Set the walking animation to true
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            animator.SetBool("isIdle", true);// Set the Idle animation to true
        }

        // Conditions when "A" key pressed
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);// Set the soldier left movement speed
            animator.SetBool("isWalkLeft", true);// Set the walking animation to true
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("isWalkLeft", false);// set the walkleft animation to false
            animator.SetBool("isIdle", true);// Set the Idle animation to true
        }

        // Conditions when "S" key pressed
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);// Set the soldier backward speed
            animator.SetBool("isIdle", false);// Set the walking animation to true
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            animator.SetBool("isIdle", true);// Set the Idle animation to true
        }

        // Conditions when "D" key pressed
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);// Set the soldier right movement speed
            animator.SetBool("isWalkRight", true);// Set the walking animation to true
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("isWalkRight", false);// set the walkright animation to false
            animator.SetBool("isIdle", true);// Set the Idle animation to true
        }

        // Conditions when "LeftArrow" key pressed
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0, Time.deltaTime * -rotateSpeed, 0));// Set the Rotate left speed 
        }

        // Conditions when "RightArrow" key pressed
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0, Time.deltaTime * rotateSpeed, 0));// Set the Rotate right speed 
        }

        // Conditions when "Space" key pressed
        if (Input.GetKeyDown(KeyCode.Space) && spacePressed < 1)
        {
            playerRb.AddForce(Vector3.up * jump, ForceMode.Impulse);// Set jump velocity of soldier
            spacePressed += 1;// Set the jump count to 1
        }

        // Conditions when "T" key pressed
        if (Input.GetKeyDown(KeyCode.T))
        {
            // Check if tPRessed is 0
            if (tPressed == 0)
            {
                CameraChange1();// If so, call the CameraChange1 Function
            }
            // Check if tPressed is 1
            else if (tPressed == 1)
            {
                CameraChange2();// If so, call the CameraChange2 Function
            }
        }

        // Conditions when "C" key pressed
        if (Input.GetKeyDown(KeyCode.C) && fleshOn == true)
        { 
            FleshLight.enabled = true;// Set the flashlight to enabled if C key is pressed
        }
        else if (Input.GetKeyDown(KeyCode.C) && fleshOn == false)
        {
            FleshLight.enabled = false;// Set the flashlight to disable if C key pressed again
        }
        else
        {
            fleshOn = !fleshOn;
        }

        // Check if the ammoCount is lesser or equal to 20, ammoCount is not equal to Zero and is not reloading
        if (ammoCount <= 20 & ammoCount != 0 & isReloading == false)
        {
            // Conditions when "Q" key pressed
            if (Input.GetKeyDown(KeyCode.Q))
            {
                animator.SetTrigger("triggShooting");// Soldier Anim will play the shooting Animation

                audioSource.PlayOneShot(PlayerAudioClipArr[0], 0.2f);// Play the shooting audio in the specific array

                PlayerShoot();// Call the PlayerShoot Function

                ammoCount -= 1;// Decrease the ammoCount by 1
            }
        }
        else if (isReloading == true)// If reloading is true
        {
            isReloading = false;// Will set reloading bool to false
        }

        // Check if player health is zero
        if(PlayerHealth.health == 0)
        {
            EnemyScript.zomFollow = false; // Set the zomFollow bool in the EnemyScript

            animator.SetTrigger("triggDeath");// Play the Soldier Death animation

            StartCoroutine(playerDeath());// Start the playerDeath Coroutine
        }

        // Check if addedAmmo bool is true from purchaseAmmo script
        if (PurchaseAmmo.addedAmmo == true)
        {
            animator.SetTrigger("triggReloading");

            isReloading = true;// Set the reloading bool to true

            audioSource.PlayOneShot(PlayerAudioClipArr[1], 0.2f);// Play Purchase ammo audio

            PurchaseAmmo.addedAmmo = false;// Set the reloading bool back to false
        }
    }

    // Changing the Camera 1 Function
    private void CameraChange1()
    {
        cam1.SetActive(true);
        cam2.SetActive(false);
        tPressed = 1;
    }

    // Changing the Camera 2 Function
    private void CameraChange2()
    {
        cam1.SetActive(false);
        cam2.SetActive(true);
        tPressed = 0;
    }

    // Changing the Camera 3 Function(Death Cam)
    private void CameraChange3()
    {
        cam1.SetActive(false);
        cam2.SetActive(false);
        cam3.SetActive(true);
        tPressed = 0;
    }

    //PlayerShoot Function
    private void PlayerShoot()
    {
        Instantiate(bulletPrefab, bulletSpawn.transform.position, transform.rotation);// Instatiate the bullet prefab at the bullet spawn point position
        muzzleFlash.Play();// Play the muzzle Flash animation when called
    }

    // PlayerRaycast Function
    private void PlayerRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam1.transform.position, cam1.transform.forward, out hit, range))
        {
            // Check if hit Raycast "HITs" the tagged object and zombiesKilles is more or equal to 10
            if (hit.collider.tag == "Button" && EnemyScript.zombsKilled >= 10)
            {
                if(Input.GetKey(KeyCode.F))
                {
                    Doors.btnBool = true;// Set the btnbool in doors script to true
                }
            }
            // Check if hit Raycast "HITs" the tagged object and zombiesKilles is lesser or equal to 10
            else if (hit.collider.tag == "Button" && EnemyScript.zombsKilled <= 10)
            {
                if(Input.GetKey(KeyCode.F))
                {
                    StartCoroutine(_btnWarningWait());// Call btnWarning Coroutine
                }
            }

            // Check if hit Raycast "HITs" the tagged object
            if (hit.collider.tag == "Button2")
            {
                if(Input.GetKey(KeyCode.F))
                {
                    Doors2.btnBool2 = true;// Set the btnbol in doors2 script to true
                }
            }
        }
    }

    // Set the slider for the sensitivity to let player customize the sens
    public void SetSens(float _sensitivity)
    {
        rotateSpeed = _sensitivity;
    }

    // Player Death Coroutine
    private IEnumerator playerDeath()
    {
        audioSource.PlayOneShot(PlayerAudioClipArr[2], 0.2f);// Play the death audio
        CameraChange3();// Call the CameraChange3 Function
        stopControls = true;// set the stopControls bool to true
        yield return new WaitForSeconds(2f);// Wait for 2 Seconds
        death = true;// Set death bool to true
    }

    // Teleport End Coroutine
    private IEnumerator _teleportEnd()
    {
        yield return new WaitForSeconds(0.3f);// Wait 0.3 Seconds
        SceneManager.LoadScene("WinScene");// Load the "Win Scene"
    }

    // Btn warning Coroutine
    private IEnumerator _btnWarningWait()
    {
        btnWarning.SetActive(true);// Set the warning UI to true/ Visible
        yield return new WaitForSeconds(3f);// Wait 3 seconds
        btnWarning.SetActive(false);// Set the warning UI to false/ No Visible
    }

    // Trigger Enter Conditions
    private void OnTriggerEnter(Collider other)
    {
        // Check if player has touched with the Teleporter
        if(other.gameObject.CompareTag("TeleportEnd"))
        {
            StartCoroutine(_teleportEnd());// Call the teleportEnd Coroutine
        }
    }

    // Collision Enter Conditions
    private void OnCollisionEnter(Collision collision)
    {
        // Check if player has collided with the Level2Start floor
        if(collision.gameObject.CompareTag("Level2StartFloor"))
        {
            enemySpawner.SetActive(false);// Set the lvl1 zombie spawner to false to reduce lag and not spawn more zombire prefab when not necessary
            Destroy(Spawner.enemyPrefabClone);// Destroy the enemyPrefab to reduce lag 
            BossScript.bossFollow = true;// Set the bossFollow in the BossScript to true
            enemySpawner2.SetActive(true);// Set the lvl2 zombie Spawner to true
        }

        // Check if player is colliding with the floor tag
        if(collision.gameObject.CompareTag("Floor"))
        {
            spacePressed = 0;// Set the spacePressed back to 0 to enable jumping again
        }
    }
}