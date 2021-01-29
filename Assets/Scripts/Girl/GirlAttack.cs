using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GirlAttack : MonoBehaviour, IDamagable
{
    [SerializeField] Weapon weaponPrefab;
    [SerializeField] int health = 10;
    [SerializeField] UnityEvent OnDead;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Weapon weapon = Instantiate(weaponPrefab, transform.position, Quaternion.identity);
            weapon.SetUpDirection(transform.localScale.x < 0 ? transform.right : -transform.right);
        }
    }

    public void TakeDamage(int points)
    {
        health -= points;
        if (health <= 0)
        {
            OnDead.Invoke();
            Destroy(gameObject);
        }
    }
}
