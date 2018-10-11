using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadFreezing : MonoBehaviour
{
    public GameObject cube;
    public AudioClip clip;

    private void OnEnable()
    {
        cube = Resources.Load("4 mat cube Resource") as GameObject;
        clip = Resources.Load("freezingExample") as AudioClip;

        GetComponent<AudioSource>().clip = clip;
        GetComponent<AudioSource>().Play();
    }

    private void OnDisable()
    {
        cube = null;
        clip = null;

        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().clip = null;

        Resources.UnloadUnusedAssets();
    }
}
