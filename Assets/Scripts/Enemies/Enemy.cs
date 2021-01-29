using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int health = 1;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(int points)
    {
        health -= points;
        animator.SetTrigger("OnDamaged");
        if (health <= 0)
            animator.SetTrigger("OnDead");
    }

    public void OnDead()
    {
        Destroy(gameObject);
    }
}
