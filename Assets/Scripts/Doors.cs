using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Behaviour[] components;

    // Start is called before the first frame update
    void Start()
    {
        EnemyManager.current.onEnemiesDestroyed += OnEnemiesDestroyed;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
        components = GetComponents<Behaviour>();
        foreach (Behaviour component in components)
        {
            if (component == this)
                continue;
            component.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnEnemiesDestroyed()
    {
        spriteRenderer.enabled = true;
        foreach (Behaviour component in components)
            component.enabled = true;
    }
}
