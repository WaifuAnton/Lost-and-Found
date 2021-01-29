using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlAttack : MonoBehaviour
{
    [SerializeField] Knife knifePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Knife knife = Instantiate(knifePrefab, transform.position, Quaternion.identity);
            knife.SetUpDirection(transform.localScale.x < 0 ? true : false);
        }
    }
}
