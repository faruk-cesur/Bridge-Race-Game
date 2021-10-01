using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public AudioClip collectableSound, loseGameSound, winGameSound;

    public AudioSource audioSource;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }

        audioSource = GetComponent<AudioSource>();
    }


    public void PlaySound(AudioClip clip, float volume)
    {
        audioSource.PlayOneShot(clip, volume);
    }

    public IEnumerator LoseGameSound()
    {
        PlaySound(Instance.loseGameSound, 1);
        yield return new WaitForSeconds(2f);
    }
}