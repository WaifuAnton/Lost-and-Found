using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected float speed = 10;
    [SerializeField] protected int damage = 1;
    [SerializeField] protected string target;
    protected Vector2 direction = Vector2.zero;
    protected bool justCreated = false;

    private void Start()
    {
        justCreated = true;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
        justCreated = false;
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == target)
        {
            IDamagable damagable = collision.gameObject.GetComponent<IDamagable>();
            damagable.TakeDamage(damage);
        }
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    public virtual void SetUpDirection(Vector2 direction)
    {
        if (direction.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);
        this.direction = direction.normalized;
    }
}
