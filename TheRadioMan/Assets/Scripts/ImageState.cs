using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageState : MonoBehaviour
{
    [SerializeField]private string stateName;
    [SerializeField]private SpriteRenderer image;
    [SerializeField]private AudioClip clip;

    public void Activate() {
        image.enabled = true;
        if(clip != null) {
            AudioManager.Instance.ForceSound(clip, false);
        }
    }
    
    public void Deactivate() {
        image.enabled = false;
    }
}
