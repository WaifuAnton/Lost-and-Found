using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bomb : Weapon
{
    [SerializeField] UnityEvent OnDestroy;

    public override void SetUpDirection(Vector2 direction)
    {
        if (direction.x < 0)
            transform.localScale = new Vector3(-3, 3, 3);
        this.direction = direction.normalized;
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        OnDestroy.Invoke();
        base.OnCollisionEnter2D(collision);
    }
}
