using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class BossScript : MonoBehaviour
{

    private NavMeshAgent zomMesh;

    public GameObject Soldier;
    public Animator zomAnim;
    public AudioClip[] ZomClipArr;


    public float bossDistRun = 6.0f;

    public static bool bossDeath = false;
    public static float _bossHealth;
    public static float _bossMaxHealth = 100f;
    public static bool bossFollow = true;


    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        zomMesh = GetComponent<NavMeshAgent>();

        Soldier = GameObject.FindGameObjectWithTag("Player");

        zomAnim = FindObjectOfType<Animator>();

        zomAnim.SetBool("isWalk", false);

        audioSource = GetComponent<AudioSource>();

        audioSource.PlayOneShot(ZomClipArr[0], 0.1f);

        bossFollow = false;

        _bossHealth = 100f;

        bossDeath = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (bossDeath == false && bossFollow == true)
        {
            BossAI();
        }

        if(_bossHealth <= 0)
        {
            bossDeath = true;
        }

        BossDeath();
    }

    private void BossAI()
    {
        float dist = Vector3.Distance(transform.position, Soldier.transform.position);

        if (dist < bossDistRun)
        {
            Vector3 direcToSoldier = transform.position - Soldier.transform.position;

            Vector3 newPos = transform.position - direcToSoldier;

            zomMesh.SetDestination(newPos);

            zomAnim.SetBool("isWalk", true);
        }


        if (dist > bossDistRun)
        {
            zomAnim.SetBool("isWalk", false);
        }
    }

    private void BossDeath()
    {
        if (bossDeath == true)
        {
            Destroy(gameObject, 3f);
            Destroy(this);

            zomAnim.SetTrigger("triggDeath");

            bossDeath = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            _bossHealth -= 1;
        }
    }
}
