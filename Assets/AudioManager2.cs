using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager2 : MonoBehaviour
{

	[SerializeField] private AudioMixer _mainMixer;

    private AudioMixerSnapshot ambienteMixerSnapshot;
    private AudioMixerSnapshot animaliMixerSnapshot;


    // Start is called before the first frame update
    

    void Start () {
     	
     	ambienteMixerSnapshot = _mainMixer.FindSnapshot("Ambiente");
        animaliMixerSnapshot = _mainMixer.FindSnapshot("Animali");

    }

  
}
