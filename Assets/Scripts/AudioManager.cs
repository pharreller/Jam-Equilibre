using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AudioManager : MonoBehaviour
{
    private AudioSource[] audioSources;
    public float delay;
    private int previouslyPlayed =-1;

    private void Start()
    {
        audioSources=GetComponents<AudioSource>();
    }

    public IEnumerator PlayRandomAudio()
    {
        int randIndex = Random.Range(0, audioSources.Length - 1);
        if (previouslyPlayed!=-1 && randIndex == previouslyPlayed)
        {
            if (audioSources[randIndex-1]!=null)
            {
                randIndex -= 1;
            }
            else
            {
                randIndex += 1;
            }
        }
        audioSources[randIndex].Play();
        previouslyPlayed = randIndex;
        yield return new WaitForSeconds(delay);
    }
}
