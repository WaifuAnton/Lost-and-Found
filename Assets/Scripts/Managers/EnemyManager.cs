using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager current;

    public event Action onEnemiesDestroyed;
    AudioSource audioSource;

    private void Awake()
    {
        current = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        int totalEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (totalEnemies == 0)
        {
            onEnemiesDestroyed?.Invoke();
            audioSource.Play();
            enabled = false;
        }
    }
}
