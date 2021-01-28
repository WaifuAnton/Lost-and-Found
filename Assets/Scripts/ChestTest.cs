using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestTest : MonoBehaviour
{
    AudioSource audioSource;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        animator.SetTrigger("OnUnlocked");
        if (!audioSource.isPlaying)
            audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
