using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance;
    public static SoundManager Instance => _instance;

    public AudioClip collectableSound, loseGameSound, winGameSound;

    public AudioSource audioSource;


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
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