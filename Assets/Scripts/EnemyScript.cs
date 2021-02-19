using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    /*public static int enemyHealth = 10;

    public float lookingRadius = 2f;

    public Animator zomAnim;

    Transform player;

    NavMeshAgent agentMesh;
    // Start is called before the first frame update
    void Start()
    {
        agentMesh = GetComponent<NavMeshAgent>();

        player = PlayerManager.instance.player.transform;

        zomAnim.SetBool("isIdle", true);
    }

    // Update is called once per frame
    void Update()
    {
        float disc = Vector3.Distance(player.position, transform.position);

        if (disc <= lookingRadius)
        {
            agentMesh.SetDestination(player.position);

            zomAnim.SetBool("isIdle", false);

            if (disc <= agentMesh.stoppingDistance)
            {
                FaceTarget();
            }
        }


        Debug.Log(enemyHealth);
        //CheckEnemyHealth();
    }

    private void FaceTarget()
    {
        Vector3 drc = (player.position - transform.position).normalized;
        Quaternion lookRotate = Quaternion.LookRotation(new Vector3(drc.x, 0, drc.z));
        transform.rotation = Quaternion.Slerp(player.rotation, lookRotate, Time.deltaTime * 5f);

        zomAnim.SetBool("isIdle", true);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, lookingRadius);
    }


    private void CheckEnemyHealth()
    {
        if (enemyHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }*/

    //public Transform soldier;
    //public Rigidbody zomRigidBody;
    //public Animator zomAnim;

    //public float moveSpeed;
    //public float MaxDist;
    //public float MinDist;

    //void Start()
    //{
    //    zomAnim = GetComponent<Animator>();

    //    zomRigidBody = GetComponent<Rigidbody>();
    //}

    //void Update()
    //{
    //    transform.LookAt(soldier);


    //    if(Vector3.Distance(transform.position, soldier.position) >= MinDist)
    //    {
    //        //transform.position += transform.forward * moveSpeed * Time.deltaTime;

    //        zomAnim.SetBool("isIdle", false);
    //    }

    //    if(Vector3.Distance(transform.position, soldier.position) >= MaxDist)
    //    {

    //    }


    //    /*Vector3 dirc = soldier.position - transform.position;
    //    Quaternion rotation = Quaternion.LookRotation(dirc);
    //    transform.rotation = rotation;*/
    //}


    private NavMeshAgent zomMesh;

    public GameObject Soldier;

    public float zomDistRun = 6.0f;


    public Animator zomAnim;

    private void Start()
    {
        zomMesh = GetComponent<NavMeshAgent>();

        Soldier = GameObject.FindGameObjectWithTag("Player");

        zomAnim.SetBool("isIdle", true);
    }

    private void Update()
    {
        float dist = Vector3.Distance(transform.position, Soldier.transform.position);

        if(dist < zomDistRun)
        {
            Vector3 direcToSoldier = transform.position - Soldier.transform.position;

            Vector3 newPos = transform.position - direcToSoldier;

            zomMesh.SetDestination(newPos);

            zomAnim.SetBool("isIdle", false);
        }
        else
        {
            zomAnim.SetBool("isIdle", true);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            if(EnemyHealth.health <= 0)
            {
                Destroy(gameObject);
            }
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth.health -= 10;
        }
    }
}