﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour, IDamagable
{
    [SerializeField] protected int health = 1;
    [SerializeField] int contactDamage = 1;
    [SerializeField] UnityEvent OnDead;
    protected Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && health > 0)
        {
            GirlAttack girl = collision.gameObject.GetComponent<GirlAttack>();
            girl.TakeDamage(contactDamage);
        }
    }

    public void TakeDamage(int points)
    {
        health -= points;
        animator.SetTrigger("OnDamaged");
        if (health <= 0)
            animator.SetTrigger("OnDead");
    }

    public void Dying()
    {
        OnDead.Invoke();
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
