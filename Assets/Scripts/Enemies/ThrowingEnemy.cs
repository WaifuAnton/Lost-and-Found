using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingEnemy : Enemy
{
    [SerializeField] Weapon weaponPrefab;
    Vector2 direction = Vector2.zero;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            direction = collision.transform.position - transform.position;
            direction = direction.normalized;
            animator.SetTrigger("OnAttack");
        }
    }

    public void InstanciateWeapon()
    {
        Weapon weapon = Instantiate(weaponPrefab, transform.position, Quaternion.identity);
        if (direction.x < 0)
            transform.localScale = new Vector3(-3, 3, 3);
        else if (direction.x > 0)
            transform.localScale = new Vector3(3, 3, 3);
        weapon.SetUpDirection(direction);
    }
}
