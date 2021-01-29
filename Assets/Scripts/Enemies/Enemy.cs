using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected int health = 1;
    [SerializeField] int contactDamage = 1;
    Animator animator;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
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

    public virtual void OnDead()
    {
        Destroy(gameObject);
    }
}
