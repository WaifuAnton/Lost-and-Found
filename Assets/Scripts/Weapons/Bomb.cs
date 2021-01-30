using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class Bomb : Weapon
{
    public static Bomb current;
    public event Action<string> onBombDestroyed;
    public event Action onBombCreated;

    private void Awake()
    {
        current = this;
    }

    protected override void Update()
    {
        if (justCreated)
            onBombCreated?.Invoke();
        base.Update();
    }

    public override void SetUpDirection(Vector2 direction)
    {
        if (direction.x < 0)
            transform.localScale = new Vector3(-3, 3, 3);
        this.direction = direction.normalized;
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        onBombDestroyed?.Invoke("Explosion");
        base.OnCollisionEnter2D(collision);
    }
}
