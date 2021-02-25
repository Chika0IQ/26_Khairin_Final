using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{

    // Variables //

    private AudioSource audioSource;// Initialising the AudioSource as a Variable
    private NavMeshAgent zomMesh;// Setting the NavMeshAgent for the zombie

    public GameObject Soldier;// Setting the Soldier Prefab as a GameObject so i can be reference later
    public Animator zomAnim;// Setting the Animator as a variable for the Zombie
    public AudioClip[] ZomClipArr;// Setting up and array for sounds of the zombie
    public GameObject coinPrefab;// Getting the coinPrefab as a GameObject
    public Vector3 coinSpawnPoint;// Get the vector3 of the coinSpawnPoint;
    public static GameObject coinClone; // Set the coinPrefab as the coinClone

    public float zomDistRun = 6.0f;// Setting the distance of how far must soldier be before the zombies will follow
    private bool zomDeath = false;// Setting a bool for the zombieDeath

    public static bool zomFollow = true;// Setting a bool for the zombieFollow
    public static int zombsKilled = 0;// Int of how mamy zombies are killed

    void Start()
    {
        zomMesh = GetComponent<NavMeshAgent>();// Calling the NavMeshAgent Component

        Soldier = GameObject.FindGameObjectWithTag("Player");// Getting the soldier Prefab using the Find Tag function instead of dragging and dropping the soldier prefab in

        zomAnim = GetComponent<Animator>(); // Getting the Animator Component in the zombiePrefab

        zomAnim.SetBool("isWalk", false);// Set the bool animation of walking to false on start so that the zombie will be in the Idle animation when spawned

        audioSource = GetComponent<AudioSource>();// Getting the AudioSource Component in the zombiePrefab

        audioSource.PlayOneShot(ZomClipArr[0], 0.1f);// Getting the audio file that is in the array and set it to a certain volume

        zomFollow = true;// Set  the zombie Follow bool to false on Start so that if player restarts the game, the variable will be false at start

    }

    void Update()
    {

        coinSpawnPoint = transform.position;// Set the coinSpawnPoint to the zombies current position

        // If zpmbieDeath is false, zombieFollow is true and the bossDeath is false
        if (zomDeath == false && zomFollow == true && BossScript.bossDeath == false)
        {
            ZombieAI();// Will then call the ZombieAI Function
        }

        ZombieDeath();// Call the ZombieDeath Function
    }

    // ZombieAI Function
    private void ZombieAI()
    {
        // Will find the distance between zombie and soldier and will only move if the range is in the certain distance set in the inspector panel or on start
        float dist = Vector3.Distance(transform.position, Soldier.transform.position);

        if (dist < zomDistRun)
        {
            Vector3 direcToSoldier = transform.position - Soldier.transform.position;

            Vector3 newPos = transform.position - direcToSoldier;

            zomMesh.SetDestination(newPos);

            zomAnim.SetBool("isWalk", true);
        }

        // If zombie is further away from the soldier, zombie will be idle
        if (dist > zomDistRun)
        {
            zomAnim.SetBool("isWalk", false);
        }
    }

    //Zombie Death Function
    private void ZombieDeath()
    {

        // Check if the bool zomDeath is true 
        if (zomDeath == true)
        {
            audioSource.PlayOneShot(ZomClipArr[1], 0.1f);


            Destroy(gameObject, 3f);
            Destroy(this);
            zombsKilled += 1;
            zomDeath = false;

            coinClone = Instantiate(coinPrefab, coinSpawnPoint, Quaternion.identity);

            Destroy(coinClone, 6f);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        // Check if bullet is colliding with the zombiePrefab
        if (collision.gameObject.CompareTag("Bullet"))
        {
            if (EnemyHealth.health <= 0)
            {
                if (zomDeath == false)
                {
                    zomAnim.SetTrigger("triggDeath");

                    zomDeath = true;
                }
            }
        }

        // Check if the zombie is colliding with the player, will decrease the player's health by 10
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth.health -= 10;
        }

        // If any zombie were to collide with the boundary prefab, it will be destoroyed
        if(collision.gameObject.CompareTag("Boundary"))
        {
            Destroy(gameObject);
        }
    }
}