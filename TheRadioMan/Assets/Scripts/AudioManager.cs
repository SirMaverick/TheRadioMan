using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance{get; private set;}
    private AudioSource source;

    void Awake() {
        if (Instance == null) {
            Instance = this;
            if(!GetComponent<AudioSource>()){
                gameObject.AddComponent<AudioSource>();
                source = GetComponent<AudioSource>();
            }
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    public void ForceSound(AudioClip clip, bool isContinuedAfter) {
        float currentPlaybackTime = 0;
        if(isContinuedAfter) {
            currentPlaybackTime = source.time;
        }
        PlaySound(clip, currentPlaybackTime);
        
    }

    private void PlaySound(AudioClip clip, float playBackTime) {
        source.clip = clip;
        source.time = playBackTime;
        source.Play();
    }

    private void PlaySound(AudioClip clip) {
        PlaySound(clip, 0);
    }
}
