using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public GameObject bulletPrefab;// Set the bulletPrefab as a GameObject
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if colliding with Enemy
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyHealth.health -= 10; // Minus the player health by 10
        }

        // Check if colliding with the BossTorso
        if(collision.gameObject.CompareTag("BossTorso"))
        {
            BossScript._bossHealth -= 2;// Minus the health of the boss by 2
        }
    }
}