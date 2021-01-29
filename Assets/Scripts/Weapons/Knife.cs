using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : Weapon
{
    // Update is called once per frame
    protected override void Update()
    {
        transform.Translate(transform.up * speed * Time.deltaTime);
    }

    public override void SetUpDirection(bool isRight)
    {
        if (isRight)
            transform.rotation = Quaternion.Euler(0, 0, -45);
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
            transform.rotation = Quaternion.Euler(0, 0, 45);
        }
    }
}
