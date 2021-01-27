﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlMovement : MonoBehaviour
{
    [SerializeField] float speed = 20;
    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
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
        Vector2.ClampMagnitude(movement, speed);
        if (movement.magnitude > 0)
            rb2d.AddForce(movement);
        else
            rb2d.velocity = Vector2.zero;
    }
}
