using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlMovement : MonoBehaviour
{
    [SerializeField] float speed = 20;
    AudioSource audioSource;
    Animator animator;
    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if (horizontal > 0)
            transform.localScale = new Vector3(-1, 1, 1);
        else if (horizontal < 0)
            transform.localScale = new Vector3(1, 1, 1);
        Vector2 movement = new Vector2(horizontal, vertical);
        movement *= speed;
        movement = Vector2.ClampMagnitude(movement, speed);
        transform.Translate(movement * Time.deltaTime);
        if (movement.magnitude > 0 && !audioSource.isPlaying)
            audioSource.Play();
        else if (movement.magnitude == 0 && audioSource.isPlaying)
            audioSource.Stop();
        animator.SetFloat("Speed", movement.magnitude);
    }
}
