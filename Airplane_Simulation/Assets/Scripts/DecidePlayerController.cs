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

    private GameObject playerController;
    private GameObject playerCanvasParent;

    // Start is called before the first frame update
    void Start()
    {
        // Check Oculus headset does not exists and is present
        if (XRDevice.isPresent)
        {
            // Instantiate player object and assign it, playerController is not the PREFAB (OculusController)
            playerController = Instantiate(OculusController, this.gameObject.transform);

            // Assigns the parent game object of the canvas
            playerCanvasParent = playerController.transform.GetChild(1).GetChild(0).GetChild(1).gameObject;

            // Move the canvas object to the correct camera
            //canvasText.transform.parent = playerCanvasParent.transform;
            canvasText.transform.SetParent(playerCanvasParent.transform);
        }
        else
        {
            // Instantiate player object and assign it, playerController is not the PREFAB (FPSController)
            playerController = Instantiate(FPSController, this.gameObject.transform);

            // Assigns the parent game object of the canvas
            playerCanvasParent = playerController.transform.GetChild(0).gameObject;

            // Move the canvas object to the correct camera
            //canvasText.transform.parent = playerCanvasParent.transform;
            canvasText.transform.SetParent(playerCanvasParent.transform);
        }
    }

    public GameObject getPlayerController()
    {
        return playerController;
    }
}
