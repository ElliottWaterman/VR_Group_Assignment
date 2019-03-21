using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneSounds : MonoBehaviour
{
    public AudioSource Source;

    public AudioClip taxiSample;
    public AudioClip safetyAnouncment;
    public AudioClip takeOffSample;
    public AudioClip landingSample;
    public AudioClip turbulanceAnouncement;
    public AudioClip turbulanceSample;
    public AudioClip noiseLoop;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void playTaxiSound() {

        Source.PlayOneShot(taxiSample);
    }
    void playSafetyAnouncment()
    {

        Source.PlayOneShot(safetyAnouncment);
    }

    void playTakeOff() {

        Source.PlayOneShot(takeOffSample);
    }

    void playLanding() {

        Source.PlayOneShot(landingSample);
    }

    void playTurbulanceAnouncment() {

        Source.PlayOneShot(turbulanceAnouncement);
    }

    void playTurbulance() {

        Source.PlayOneShot(turbulanceSample);
    }

    void playBackgroundLoop() {

        Source.PlayOneShot(noiseLoop);
    }
}
