using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NightEnemyManager : MonoBehaviour
{
    [SerializeField] UnityEvent OnEnemiesDestroyed;
    int totalEnemies;

    // Start is called before the first frame update
    void Start()
    {
        totalEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (totalEnemies == 0)
            OnEnemiesDestroyed.Invoke();
    }

    public void DecreaseEnemies()
    {
        totalEnemies--;
    }
}
