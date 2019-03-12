using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityStandardAssets.Characters.FirstPerson;

public class DecidePlayerController : MonoBehaviour
{
    public GameObject OculusController;
    public GameObject FPSController;
    public GameObject canvasText;

    GameObject canvasParent;

    // Start is called before the first frame update
    void Start()
    {
        // Check Oculus headset does not exists and is present
        if (XRDevice.isPresent)
        {
            Instantiate(OculusController, this.gameObject.transform);

            // Assigns the parent game object of the canvas
            canvasParent = OculusController.transform.GetChild(1).GetChild(0).GetChild(1).gameObject;

            // Move the canvas object to the correct camera
            canvasText.transform.parent = canvasParent.transform;
        }
        else
        {
            Instantiate(FPSController, this.gameObject.transform);

            // Assigns the parent game object of the canvas
            canvasParent = FPSController.transform.GetChild(0).gameObject;

            // Move the canvas object to the correct camera
            canvasText.transform.parent = canvasParent.transform;
        }
    }
}
