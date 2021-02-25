using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{

    private AudioSource audioSource;// Get the AudioSource 
    public AudioClip[] AudioClipArr; // Set a Array for the bgm


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();// Call the AudioSource Component

        audioSource.PlayOneShot(AudioClipArr[0], 0.1f);// Play the audio in the select array number with the certain volume
        audioSource.enabled = true;// Enable the audio source on start
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
