using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected float speed = 10;
    [SerializeField] int damage = 1;
    [SerializeField] string target;
    bool isRight = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (isRight)
            transform.Translate(transform.right * speed * Time.deltaTime);
        else
            transform.Translate(-transform.right * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == target)
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    public virtual void SetUpDirection(bool isRight)
    {
        if (isRight)
            transform.rotation = Quaternion.Euler(0, 0, -45);
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
            transform.rotation = Quaternion.Euler(0, 0, 45);
        }
    }
}
