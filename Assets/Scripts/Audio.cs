using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public List<AudioClip> soundtrack;
    AudioSource auxSauce;
    private void Awake()
    {
        auxSauce = gameObject.GetComponent<AudioSource>();
    }
    void Start()
    {
        if (!auxSauce.playOnAwake)
        {
            //random song choosing
            auxSauce.clip = soundtrack[Random.Range(0, soundtrack.Count)];
            auxSauce.Play();
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (!auxSauce.isPlaying)
        {
            //changes song after a song ends
            auxSauce.clip = soundtrack[Random.Range(0, soundtrack.Count)];
            auxSauce.Play();
        }
    }
}
