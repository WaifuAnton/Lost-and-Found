using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] string[] clipNames;
    [SerializeField] AudioClip[] audioClips;
    Dictionary<string, AudioClip> audios = new Dictionary<string, AudioClip>();
    AudioSource audioSource;
    public float delay { get; set; }

    private void Awake()
    {
        if (clipNames.Length != audioClips.Length)
            throw new ArgumentException("Size of clips array must be the same as size of names");
        for (int i = 0; i < clipNames.Length; i++)
            audios.Add(clipNames[i], audioClips[i]);
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayClip(string soundName)
    {
        audioSource.clip = audios[soundName];
        audioSource.PlayDelayed(delay);
    }

    public float GetClipLength(string soundName)
    {
        return audios[soundName].length;
    }
}
