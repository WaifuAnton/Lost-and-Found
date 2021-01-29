using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GirlAttack : MonoBehaviour
{
    [SerializeField] Knife knifePrefab;
    [SerializeField] int health = 10;
    [SerializeField] UnityEvent OnDead;

    // Start is called before the first frame update
    void Start()
    {
        //soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
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

    public void TakeDamage(int points)
    {
        health -= points;
        if (health <= 0)
        {
            OnDead.Invoke();
            //StartCoroutine(ReloadLevel());
        }
    }

    //IEnumerator ReloadLevel()
    //{
    //    yield return new WaitForSeconds(soundManager.GetClipLength("Death"));
    //    SceneManager.LoadScene("Night");
    //}
}
