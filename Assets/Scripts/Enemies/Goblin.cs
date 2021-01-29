using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : Enemy
{
    [SerializeField] Weapon weaponPrefab;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Weapon weapon = Instantiate(weaponPrefab, transform.position, Quaternion.identity);
            Vector2 direction = collision.transform.position - transform.position;
            direction = direction.normalized;
            weapon.SetUpDirection(direction);
        }
    }
}
