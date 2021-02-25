using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    public float speed;// Set the speed of the bullet
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3);// Destroy the bulletPrefab after 3 seconds
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;// Move the bulletPrefab forward with the speed set
    }
}