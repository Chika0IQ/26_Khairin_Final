using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{

    private AudioSource audioSource;
    public AudioClip[] AudioClipArr;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.PlayOneShot(AudioClipArr[0], 0.1f);
        audioSource.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
