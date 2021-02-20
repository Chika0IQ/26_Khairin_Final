﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{

    private NavMeshAgent zomMesh;

    public GameObject Soldier;
    public Animator zomAnim;

    public float zomDistRun = 6.0f;

    private bool zomDeath = false;
    private float speed = 2f;

    private AudioSource audioSource;
    public AudioClip[] ZomClipArr;

    void Start()
    {
        zomMesh = GetComponent<NavMeshAgent>();

        Soldier = GameObject.FindGameObjectWithTag("Player");

        zomAnim = FindObjectOfType<Animator>();
        
        zomAnim.SetBool("isWalk", false);

        audioSource = GetComponent<AudioSource>();

        audioSource.PlayOneShot(ZomClipArr[0], 0.1f);
    }

    void Update()
    {
        if(zomDeath == false)
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
            zomAnim.SetBool("isWalk",false);
        }
    }

    private void ZombieDeath()
    {
        if (zomDeath == true)
        {
            Destroy(gameObject, 3f);

            zomDeath = false;
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
    }
}