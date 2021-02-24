using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{

    private NavMeshAgent zomMesh;

    public GameObject Soldier;
    public Animator zomAnim;
    public AudioClip[] ZomClipArr;
    public GameObject coinPrefab;
    public Vector3 coinSpawnPoint;
    public static GameObject coinClone;

    public float zomDistRun = 6.0f;

    private bool zomDeath = false;
    public static bool zomFollow = true;
    public static int zombsKilled = 0;


    private AudioSource audioSource;
    
    

    void Start()
    {
        zomMesh = GetComponent<NavMeshAgent>();

        Soldier = GameObject.FindGameObjectWithTag("Player");

        zomAnim = FindObjectOfType<Animator>();
        
        zomAnim.SetBool("isWalk", false);

        audioSource = GetComponent<AudioSource>();

        audioSource.PlayOneShot(ZomClipArr[0], 0.1f);

        zomFollow = true;

        coinSpawnPoint = transform.position;
    }

    void Update()
    {


        if(zomDeath == false && zomFollow == true)
        {
            ZombieAI();
        }

        ZombieDeath();
    }

    private void ZombieAI()
    {
        float dist = Vector3.Distance(transform.position, Soldier.transform.position);

        if (dist < zomDistRun)
        {
            Vector3 direcToSoldier = transform.position - Soldier.transform.position;

            Vector3 newPos = transform.position - direcToSoldier;

            zomMesh.SetDestination(newPos);

            zomAnim.SetBool("isWalk", true);
        }


        if (dist > zomDistRun)
        {
            //zomAnim.GetComponent<Animator>();
            //zomAnim.SetBool("isWalk", false);
        }
    }

    private void ZombieDeath()
    {
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

        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth.health -= 10;
        }

        if(collision.gameObject.CompareTag("Boundary"))
        {
            Destroy(gameObject);
        }
    }
}