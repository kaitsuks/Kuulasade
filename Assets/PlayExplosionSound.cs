using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayExplosionSound : MonoBehaviour {

    //public AudioClip audioClip;
    public AudioClip distantexplosion;
    AudioSource audioSource;
    //AudioSource audioSource = .AddComponent<AudioSource>() as AudioSource;

    // UnityEngine.

    // Use this for initialization
    void Start () {
        //audioSource = gameObject.GetComponentInParent<AudioSource>();
        distantexplosion = (AudioClip) Resources.Load("Sounds/distantexplosion");

    }

    void Awake()
    {

        audioSource = GetComponent<AudioSource>();
        //audioSource.

    }

    public void Playit()
    {
        //StartCoroutine(PlaySound());
        PlaySound();
    }


	public void PlaySound()
    {
        Debug.Log("Play Sound called!");
        //audioSource.PlayOneShot(distantexplosion, 1.0f);
        //audioSource.Play();
        audioSource.PlayOneShot(distantexplosion);


    }

	// Update is called once per frame
	void Update () {
        //audioSource.PlayOneShot(clip1);
    }
}
