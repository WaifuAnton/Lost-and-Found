using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Summon : Weapon
{
    [SerializeField] UnityEvent OnDead;
    Animator animator;
    Transform girl;
    float clipLength;
    float currentTime = 0;
    bool isMoving = true;

    private void Start()
    {
        girl = GameObject.FindGameObjectWithTag("Player")?.transform;
        animator = GetComponent<Animator>();
        AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
        foreach (AnimationClip clip in clips)
            if (clip.name == "Appear")
            {
                clipLength = clip.length;
                break;
            }
    }

    protected override void Update()
    {
        if (currentTime >= clipLength && isMoving && girl != null)
        {
            direction = girl.position - transform.position;
            SetUpDirection(direction);
            base.Update();
        }  
        else
            currentTime += Time.deltaTime;
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == target)
        {
            IDamagable damagable = collision.gameObject.GetComponent<IDamagable>();
            damagable.TakeDamage(damage);
            OnDead.Invoke();
            Destroy(gameObject);
        }
        else
        {
            animator.SetTrigger("OnDead");
            OnDead.Invoke();
        }
    }

    public void StopMovement()
    {
        isMoving = false;
    }
}
