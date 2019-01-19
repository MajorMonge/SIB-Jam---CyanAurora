using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBehaviour : MonoBehaviour
{

    public GameObject source;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator PlayClip(AudioClip clip)
    {
        AudioSource audio = source.GetComponent<AudioSource>();
        audio.clip = clip;
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
    }
}
