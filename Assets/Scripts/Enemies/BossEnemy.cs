using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Pathfinding;

public class BossEnemy : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float distance = 0.5f;
    Animator animator;
    Seeker seeker;
    HittingEnemy hittingEnemy;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        seeker = GetComponent<Seeker>();
        hittingEnemy = GetComponent<HittingEnemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null || Vector2.Distance(transform.position, target.position) >= distance)
        {
            seeker.enabled = true;
            animator.SetBool("IsAttacking", false);
        }
        else
        {
            seeker.enabled = false;
            animator.SetBool("IsAttacking", true);
        }
    }
}
