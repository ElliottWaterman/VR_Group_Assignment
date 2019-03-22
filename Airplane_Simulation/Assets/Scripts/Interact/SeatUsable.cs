using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class SeatUsable : UsableObject
{
    private const string SIT_DOWN = "Sit Down on";
    private const string STAND_UP = "Stand Up from";
    private const string TAXI_TO_RUNWAY = "Taxi";
    private const string LANDING = "Landing";

    public GameObject player;

    private Transform playerTransform;
    private Animator aeroplaneAnimator;
    private AudioSource planeAudio;

    public bool playerEntered = false;

    private int animationCounter = 0;

    // Use this for initialization
    void Start ()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        aeroplaneAnimator = GameObject.FindGameObjectWithTag("Aeroplane").GetComponent<Animator>();

        planeAudio = GetComponent<AudioSource>();

        if (playerTransform == null)
        {
            Debug.LogError("Instatiated player transform not found.");
        }

        if (aeroplaneAnimator == null)
        {
            Debug.LogError("Aeroplane animator component not found.");
        }

    }

    private void Update()
    {
        if (playerEntered)
        {
            // If input pressed and plane is idle then sit down or stand up
            if (this.isInputPressed() && (aeroplaneAnimator.GetCurrentAnimatorStateInfo(0).IsName("PlaneIdle") || aeroplaneAnimator.GetCurrentAnimatorStateInfo(0).IsName("InAirIdle")))
            {
                // Use the object
                this.OnUse();
            }
        }

        // Always update the player position to seat if sat down
        if (objectUsed)
        {
            // Lock instantiated player to seat position
            if (!XRDevice.isPresent)
                playerTransform.position = this.gameObject.transform.position;

            // If object is used always set player as entered
            playerEntered = true;
        }
    }

    public override void OnUse()
    {
        // Player is present and not sat down
        if (playerEntered && !objectUsed)
        {
            this.ToggleObjectUsed();

            // SIT DOWN
            SitDown();

            // Start animations
            if (animationCounter == 0)
            {
                PlaneAnimationControl(TAXI_TO_RUNWAY);
                animationCounter++;
            }
            // Walking around during flight then sit down to land
            else if (animationCounter == 1)
            {
                PlaneAnimationControl(LANDING);
                animationCounter++;
            }

            // Hide interact text on the screen
            //this.HideText();
        }
        // Player is present and is sat down
        else if (playerEntered && objectUsed)
        {
            this.ToggleObjectUsed();

            // Stand up
            StandUp();

            // Show interact text on the screen
            this.DisplayText();
        }
    }

    private void PlaneAnimationControl(string transitionText)
    {
        aeroplaneAnimator.SetTrigger(transitionText);
    }

    private void SitDown()
    {
        // Set position just before sitting down so when stand up it moves there
        if (!XRDevice.isPresent)
            player.transform.position = playerTransform.position;

        // Set player parent transform to seat transform
        player.transform.parent = this.gameObject.transform;

        // Set instantiated player transform to seat transform
        if (!XRDevice.isPresent)
            playerTransform.parent = this.gameObject.transform;
    }

    private void StandUp()
    {
        if (animationCounter == 1 && !XRDevice.isPresent)
        {
            // Set player parent transform to nothing
            player.transform.parent = null;

            // Get world postion (not relative to plane)
            Vector3 standPosition = player.transform.position;

            //player.transform.position = standPosition;

            // Take off seat
            playerTransform.parent = null;

            // Set to stand position
            playerTransform.position = standPosition;

            // Set instantiated player transform to player transform
            playerTransform.parent = player.transform;
        }
        else
        {
            // Set player parent transform to nothing
            player.transform.parent = null;

            // Set instantiated player transform to player transform
            if (!XRDevice.isPresent)
                playerTransform.parent = player.transform;
        }
    }

    public override void DisplayText()
    {
        this.interactText.enabled = true;
        this.interactText.text = "Press " + this.interactKey.ToString() + " to " 
            + (objectUsed ? STAND_UP : SIT_DOWN) + " Seat";
    }

    private void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            playerEntered = true;

            // Show interact text on the screen
            this.DisplayText();
        }
    }

    private void OnTriggerExit(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            playerEntered = false;

            // Hide interact text on the screen
            this.HideText();
        }
    }
}
