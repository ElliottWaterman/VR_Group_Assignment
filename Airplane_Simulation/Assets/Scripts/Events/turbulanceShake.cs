using UnityEngine;
using System.Collections;
using System;

public class TurbulanceShake : MonoBehaviour
{
    // Transform of the camera to shake. Grabs the gameObject's transform
    // if null.
    public Transform camTransform;
    public AudioSource turbulanceSample;
    private bool sleep = false;
    public float sleeptime;

    // How long the object should shake for.
    public float shakeDuration = 10f;

    // Amplitude of the shake. A larger value shakes the camera harder.
    public float shakeAmount = 0.5f;
    public float decreaseFactor = 0.5f;

    Vector3 originalPos;

    private void Start(){
        
    }
    void Awake(){

        ulong sampleWaitTime = Convert.ToUInt64(sleeptime) * 44100; // Converts to a 44100hz sample eg 44100 == 1 second
        turbulanceSample.Play(sampleWaitTime);
        StartCoroutine(Sleep()); 
        if (camTransform == null)
        {
            camTransform = GetComponent(typeof(Transform)) as Transform;
        }
    }

    void OnEnable()
    {
        originalPos = camTransform.localPosition;
    }

    IEnumerator Sleep() {
        
        sleep = true;
        turbulanceSample = GetComponent<AudioSource>();
        yield return new WaitForSeconds(sleeptime);
        
        Debug.Log("Turbulance Sample");
        sleep = false;
    }

    void Update()
    {
        Debug.Log("Update");
        if (shakeDuration > 0 && sleep == false)
        {   
            camTransform.localPosition = originalPos + UnityEngine.Random.insideUnitSphere * shakeAmount;

            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else if(sleep == false)
        {
            shakeDuration = 0f;
            camTransform.localPosition = originalPos;
        }
    }
}