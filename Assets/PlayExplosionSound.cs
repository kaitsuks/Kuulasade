using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayExplosionSound : MonoBehaviour {

    public AudioClip audioClip;
    //public AudioClip distantexplosion;
    AudioSource audioSource;
    //AudioSource audioSource = AddComponent<AudioSource>();

    // UnityEngine.

    // Use this for initialization
    void Start () {
        audioSource = gameObject.GetComponentInParent<AudioSource>();
        //audioSource = AddComponent<AudioSource>();
        audioClip = (AudioClip) Resources.Load("Sounds/front-desk-bells-daniel_simon");
    }

    void Awake()
    {

        //audioSource = GetComponent<AudioSource>();
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
        audioSource.PlayOneShot(audioClip, 1.0f);


    }

	// Update is called once per frame
	void Update () {
        //audioSource.PlayOneShot(clip1);
    }
}
