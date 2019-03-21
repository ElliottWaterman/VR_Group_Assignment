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

    public SeatUsable seatScript;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void playTaxiSound() {
        Source.volume = 0.3f;
        Source.PlayOneShot(taxiSample);
    }
    void playSafetyAnouncment()
    {
        Source.volume = 0.7f;
        Source.PlayOneShot(safetyAnouncment);
    }

    void playTakeOff() {
        Source.volume = 0.7f;
        Source.PlayOneShot(takeOffSample);
    }

    void allowStandUp()
    {
        seatScript.playerEntered = true;
        seatScript.DisplayText();
    }

    void playLanding() {
        Source.volume = 0.6f;
        Source.PlayOneShot(landingSample);
    }

    void playTurbulanceAnouncment() {

        Source.PlayOneShot(turbulanceAnouncement);
    }

    void playTurbulance() {

        Source.PlayOneShot(turbulanceSample);
    }

    void playBackgroundLoop() {
        Source.volume = 0.5f;
        Source.PlayOneShot(noiseLoop);
    }
}
