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
        Debug.Log("Start");
        
    }
    void Awake(){

        ulong sampleWaitTime = Convert.ToUInt64(sleeptime) * 44100; // Converts to a 44100hz sample eg 44100 == 1 second
        Debug.Log("Print Shit: " + sampleWaitTime);

        turbulanceSample.Play(sampleWaitTime);
        StartCoroutine(Sleep()); 
        Debug.Log("Awake");
        if (camTransform == null)
        {
            camTransform = GetComponent(typeof(Transform)) as Transform;
        }
    }

    void OnEnable()
    {
        Debug.Log("OnEnable");
        originalPos = camTransform.localPosition;
    }

    IEnumerator Sleep() {
        
        sleep = true;
        turbulanceSample = GetComponent<AudioSource>();
        yield return new WaitForSeconds(sleeptime);
        
        Debug.Log("Turbulance Sample");
        
        Debug.Log("Fak this why is there no .sleep function");
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