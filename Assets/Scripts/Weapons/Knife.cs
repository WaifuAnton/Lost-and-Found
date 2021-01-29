using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : Weapon
{
    public override void SetUpDirection(Vector2 direction)
    {
        if (direction.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, -45);
            this.direction = (new Vector2(1, 0) + new Vector2(0, 1)).normalized;
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
            transform.rotation = Quaternion.Euler(0, 0, 45);
            this.direction = (new Vector2(-1, 0) + new Vector2(0, 1)).normalized;
        }
    }
}
