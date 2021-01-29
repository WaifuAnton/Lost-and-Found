using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Weapon
{
    public override void SetUpDirection(Vector2 direction)
    {
        if (direction.x < 0)
            transform.localScale = new Vector3(-2.5f, 2.5f, 2.5f);
        this.direction = direction.normalized;
    }
}
