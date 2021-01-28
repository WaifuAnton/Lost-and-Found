using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlMovement : MonoBehaviour
{
    [SerializeField] float speed = 20;
    Rigidbody2D rb2d;
    AudioSource audioSource;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
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
        animator.SetFloat("Speed", movement.magnitude);
    }
}
