using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] UnityEvent OnEnemiesDestroyed;
    int totalEnemies;

    // Start is called before the first frame update
    void Start()
    {
        totalEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        //Debug.Log(totalEnemies);
    }

    // Update is called once per frame
    void Update()
    {
        if (totalEnemies == 0)
        {
            OnEnemiesDestroyed.Invoke();
            Destroy(gameObject);
        }
        //Debug.Log(totalEnemies);
    }

    public void DecreaseEnemies()
    {
        totalEnemies--;
    }
}
