using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoinMove : MonoBehaviour
{
    Vector2 startPosition;
    [SerializeField] float deltaDistance = 0.3f;
    [SerializeField] float speed = 0.15f;
    [SerializeField] UnityEvent OnPickup;
    Collider2D collider2d;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        collider2d = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(transform.position.y - startPosition.y) < deltaDistance)
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        else
            collider2d.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            OnPickup.Invoke();
    }
}
