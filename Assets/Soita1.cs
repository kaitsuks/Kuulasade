
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Soita1 : MonoBehaviour
{
    public AudioClip otherClip;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }


        IEnumerator Playit()
    {


        //audioSource.Play();
        
        audioSource.clip = otherClip;
        audioSource.PlayOneShot(otherClip, 1.0f);
        //yield return new WaitForSeconds(audio.clip.length);
        yield return new WaitForSeconds(audioSource.clip.length);
    }
}
