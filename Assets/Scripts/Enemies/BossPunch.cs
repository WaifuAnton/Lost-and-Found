using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Pathfinding;

public class BossPunch : MonoBehaviour
{
    [SerializeField] Transform target;
    //[SerializeField] UnityEvent onTargetReached;
    //[SerializeField] UnityEvent onTargetNotReached;
    Animator animator;
    Seeker seeker;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        seeker = GetComponent<Seeker>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null || Vector2.Distance(transform.position, target.position) >= 0.4f)
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
