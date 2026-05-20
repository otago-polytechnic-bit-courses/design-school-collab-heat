using System;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController Instance;
    [SerializeField] private AudioSource audioSource;

    [SerializeField] private AudioClip furnaceEnter;
    [SerializeField] private AudioClip playerJump;
    
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound(string soundType)
    {
        switch (soundType)
        {
            case "FurnaceEnter":
                audioSource.PlayOneShot(furnaceEnter);
                break;
            case "playerJump":
                audioSource.PlayOneShot(playerJump);
                break;

            default:
                break;
        }
    }
}
