using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class BossScript : MonoBehaviour
{

    private NavMeshAgent zomMesh; // Setting the NavMeshAgent for the zombieBoss
    private AudioSource audioSource; // Initialising the AudioSource as a Variable

    public GameObject Soldier; // Setting the Soldier Prefab as a GameObject so i can be reference later
    public Animator zomAnim;  // Setting the Animator as a variable for the BossZombie
    public AudioClip[] ZomClipArr; // Setting up and array for sounds of the boss

    public float bossDistRun = 6.0f; // Setting the distance of how far must soldier be before the boss will follow
    public static bool bossDeath = false; // Setting a bool for the bossDeath
    public static float _bossHealth; // Setting Variable for the boss current health
    public static float _bossMaxHealth = 100f; // Setting boss MaxHealth  
    public static bool bossFollow = true; // Setting a bool for the bossFollow


    

    // Start is called before the first frame update
    void Start()
    {
        zomMesh = GetComponent<NavMeshAgent>(); // Calling the NavMeshAgent Component

        Soldier = GameObject.FindGameObjectWithTag("Player"); // Getting the soldier Prefab using the Find Tag function instead of dragging and dropping the soldier prefab in

        zomAnim = FindObjectOfType<Animator>(); // Getting the Animator Component in the boosPrefab

        zomAnim.SetBool("isWalk", false); // Set the bool animation of walking to false on start so that the boss will be in the Idle animation when spawned

        audioSource = GetComponent<AudioSource>(); // Getting the AudioSource Component in the bossPrefab

        audioSource.PlayOneShot(ZomClipArr[0], 0.1f); // Getting the audio file that is in the array and set it to a certain volume

        bossFollow = false; // Set  the boss Follow bool to false on Start so that if player restarts the game, the variable will be false at start

        _bossHealth = 100f; // Set the health of the boss to 100 on start

        bossDeath = false; // Set the boos Death to false on start so it wont play the death animation or any other code on start
    }

    // Update is called once per frame
    void Update()
    {

        // If bossDeath is false and BossFollow is true
        if (bossDeath == false && bossFollow == true)
        {
            BossAI(); // Will can the BossAI Function only if conditions met
        }

        // If the boss Healt is lesser or equal to 0, set the bool bossDeath to true
        if(_bossHealth <= 0)
        {
            bossDeath = true;
        }

        // Call the BossDeath Function
        BossDeath();
    }


    //BossAI Function
    private void BossAI()
    {

        // Will find the distance between boss and soldier and will only move if the range is in the certain distance set in the inspector panel or on start
        float dist = Vector3.Distance(transform.position, Soldier.transform.position);

        if (dist < bossDistRun)
        {
            Vector3 direcToSoldier = transform.position - Soldier.transform.position;

            Vector3 newPos = transform.position - direcToSoldier;

            zomMesh.SetDestination(newPos);

            zomAnim.SetBool("isWalk", true);
        }

        // If boss is further away from the soldier, boss will be idle
        if (dist > bossDistRun)
        {
            zomAnim.SetBool("isWalk", false);
        }
    }


    // BossDeath Function 
    private void BossDeath()
    {

        // Check if the bool boosDeath is true 
        if (bossDeath == true)
        {
            audioSource.PlayOneShot(ZomClipArr[1], 0.1f);

            Destroy(gameObject, 3f);
            Destroy(this);

            zomAnim.SetTrigger("triggDeath");

            bossDeath = false;
        }
    }

    // Check if the Bullet is colliding with boss
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            _bossHealth -= 1; // If is colliding, will minus the boss health by 1 and will update in the bossUI
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth.health -= 10;
        }
    }
}