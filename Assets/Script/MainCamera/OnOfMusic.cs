using UnityEngine;

public class OnOfMusic : MonoBehaviour
{
   
    public void OnOffMusic()
    {
        if (GetComponent<AudioSource>().volume == 1)
        {
            GetComponent<AudioSource>().volume = 0f;
        }
        else
        {
            GetComponent<AudioSource>().volume = 1f;
        }
    }
}
