using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossOfficeLoader : MonoBehaviour
{
    GirlMovement girl;

    // Start is called before the first frame update
    void Start()
    {
        girl = GameObject.FindGameObjectWithTag("Player").GetComponent<GirlMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            SceneManager.LoadScene("BossOffice");
    }
}
