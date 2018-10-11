using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadClean : MonoBehaviour
{
    public static GameObject cube;
    public static AudioClip clip;
    private AudioSource myAudioSource;

    private void Awake()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        if (cube == null)
        {
            cube = Resources.Load("4 mat cube Resource") as GameObject;
        }

        if (clip == null)
        {
            clip = Resources.Load("freezingExampleClean") as AudioClip;
        }

        myAudioSource.clip = clip;
        myAudioSource.Play();
    }

    private void OnDisable()
    {
        myAudioSource.Stop();
        myAudioSource.clip = null;
    }
}
