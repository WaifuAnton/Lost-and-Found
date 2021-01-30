using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    AudioSource audioSource;
    Behaviour[] components;
    bool isDone = false;

    // Start is called before the first frame update
    void Start()
    {
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
        if (isDone)
            return;
        int totalEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (totalEnemies == 0)
            EnemyManager.current.onEnemiesDestroyed += OnEnemiesDestroyed;
    }

    public void OnEnemiesDestroyed()
    {
        spriteRenderer.enabled = true;
        foreach (Behaviour component in components)
            component.enabled = true;
    }
}
