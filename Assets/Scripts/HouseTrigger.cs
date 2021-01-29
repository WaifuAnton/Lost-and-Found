using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector3 pos = new Vector3(collision.transform.position.x, collision.transform.position.y, collision.transform.position.z + 6);
        collision.transform.position = pos;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Vector3 pos = new Vector3(collision.transform.position.x, collision.transform.position.y, collision.transform.position.z - 6);
        collision.transform.position = pos;
    }
}
