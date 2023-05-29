using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTypingSound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] audioClipArray;

    public AudioClip RandomClip()
    {
        return audioClipArray[Random.Range(0, audioClipArray.Length)];
    }
}
