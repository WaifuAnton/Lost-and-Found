using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy
{
    SoundManager soundManager;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnDead()
    {
        soundManager.PlayClip("Bubble");
        base.OnDead();
    }
}
