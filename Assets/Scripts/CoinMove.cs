using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMove : MonoBehaviour
{
    Vector2 startPosition;
    [SerializeField] float deltaDistance = 0.3f;
    [SerializeField] float speed = 0.15f;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(transform.position.y - startPosition.y) < deltaDistance)
            transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
}
