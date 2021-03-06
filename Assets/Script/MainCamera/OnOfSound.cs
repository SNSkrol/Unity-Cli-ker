using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOfSound : MonoBehaviour
{
    public static bool OnOffSounds=true; 

    public void OnOffSound()
    {
        if (OnOffSounds)
        {
            GetComponent<AudioSource>().Play();
        }
    }
}
