using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneSounds : MonoBehaviour
{
    public AudioSource planeAudio;

    [SerializeField] private AudioClip taxiSound;
    [SerializeField] private AudioClip takeOffSound;
    [SerializeField] private AudioClip landingSound;
    [SerializeField] private AudioClip roomNoise;

    // Start is called before the first frame update
    void Start()
    {
        // Start with quiet plane room noise
        planeAudio = GetComponent<AudioSource>();
        planeAudio.clip = roomNoise;
        planeAudio.volume = 0.1f;
        planeAudio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
