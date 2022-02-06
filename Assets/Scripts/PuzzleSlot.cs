using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSlot : MonoBehaviour
{
    public SpriteRenderer Renderer;
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip completClip;
    

    public void Placed()
    {
        source.PlayOneShot(completClip);
    }



}
