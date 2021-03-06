﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class Loader : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] string sceneName;
    [SerializeField] UnityEvent OnSceneLoading;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<GirlMovement>().enabled = false;
            collision.GetComponent<Animator>().enabled = false;
            collision.GetComponent<AudioSource>().enabled = false;
            GirlAttack girl = collision.GetComponent<GirlAttack>();
            if (girl != null)
                girl.enabled = false;
            OnSceneLoading.Invoke();
            StartCoroutine(LoadLevel());
        }
    }

    IEnumerator LoadLevel()
    {
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);
        SceneManager.LoadScene(sceneName);
    }
}
