using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    AudioSource audioSource;
    Animator animator;
    Transform girl;

    private void OnEnable()
    {
        girl = GameObject.FindGameObjectWithTag("Player").transform;
        transform.position = new Vector3(girl.position.x - 5, -2, 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animator.SetTrigger("OnUnlocked");
            if (!audioSource.isPlaying)
                audioSource.Play();
        }
    }

    public void EnableChild()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }
}
