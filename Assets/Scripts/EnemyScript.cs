using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    public static int enemyHealth = 10;

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

        zomAnim.SetBool("isIdle",true);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, lookingRadius);
    }


    private void CheckEnemyHealth()
    {
        if(enemyHealth <= 0)
        {
            //Destroy(this.gameObject);
        }
    }
}