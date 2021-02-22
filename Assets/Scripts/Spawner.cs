using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;  // EnemyPrefab
    public float spawnInterval;     // Interval between each spawn

    //Spawn Area
    public float minX;    // minX position
    public float maxX;    // maxX position
    public float minZ;    // minZ position
    public float maxZ;    // maxZ position

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitAndSpawn(spawnInterval));
    }

    // Update is called once per frame
    void Update()
    {
        //Destroy(gameObject, 10f);
    }

    private IEnumerator WaitAndSpawn(float waittime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waittime);

            Vector3 spawnPosition = new Vector3(Random.Range(minX, maxX), 0.5f, Random.Range(minZ, maxZ));

            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }
}