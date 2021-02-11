using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{

    public float lookingRadius = 2f;

    Transform player;

    NavMeshAgent agentMesh;
    // Start is called before the first frame update
    void Start()
    {
        agentMesh = GetComponent<NavMeshAgent>();

        player = PlayerManager.instance.player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float disc = Vector3.Distance(player.position, transform.position);

        if(disc <= lookingRadius)
        {
            agentMesh.SetDestination(player.position);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, lookingRadius);
    }
}
