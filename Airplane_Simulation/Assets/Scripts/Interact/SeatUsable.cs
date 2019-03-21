using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeatUsable : UsableObject
{
    private const string SIT_DOWN = "Sit Down on";
    private const string STAND_UP = "Stand Up from";
    private const string TAXI_TO_RUNWAY = "Taxi";
    private const string LANDING = "Landing";

    public GameObject player;

    private Transform playerTransform;
    private Animator areoplaneAnimator;
    private AudioSource planeAudio;

    private bool playerEntered = false;

    private int animationCounter = 0;

    // Use this for initialization
    void Start ()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        areoplaneAnimator = GameObject.FindGameObjectWithTag("Aeroplane").GetComponent<Animator>();

        planeAudio = GetComponent<AudioSource>();

        if (playerTransform == null)
        {
            Debug.LogError("Instatiated player transform not found.");
        }

        if (areoplaneAnimator == null)
        {
            Debug.LogError("Aeroplane animator component not found.");
        }

    }

    private void Update()
    {
        if (playerEntered)
        {
            // If input pressed and plane is idle then sit down or stand up
            if (this.isInputPressed() && areoplaneAnimator.GetCurrentAnimatorStateInfo(0).IsName("PlaneIdle"))
            {
                // Use the object
                this.OnUse();
            }
        }

        // Always update the player position to seat if sat down
        if (objectUsed)
        {
            // Lock instantiated player to seat position
            playerTransform.position = this.gameObject.transform.position;

            // Lock player hierarchy to seat
            //player.transform.position = this.gameObject.transform.position;
        }

        // Always check that the plane is idle so the player can see text to stand up and move
        //if (animationCounter != 0 && areoplaneAnimator.GetCurrentAnimatorStateInfo(0).IsName("PlaneIdle"))
        //{
        //    // Show interact text on the screen
        //    this.DisplayText();
        //}
        //else
        //{
        //    // Hide interact text on the screen
        //    this.HideText();
        //}
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

                planeAudio.Play();
                planeAudio.volume = 0.52f;

                animationCounter++;
            }
            // Walking around during flight then sit down to land
            else if (animationCounter == 1)
            {
                PlaneAnimationControl(LANDING);
                animationCounter++;
            }

            // Hide interact text on the screen
            this.HideText();
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
        areoplaneAnimator.SetTrigger(transitionText);
    }

    private void SitDown()
    {
        // Set position just before sitting down so when stand up it moves there
        player.transform.position = playerTransform.position;

        // Set player parent transform to seat transform
        player.transform.parent = this.gameObject.transform;
        
        // Set instantiated player transform to seat transform
        playerTransform.parent = this.gameObject.transform;
    }

    private void StandUp()
    {
        // Set player parent transform to nothing
        player.transform.parent = null;

        // Set instantiated player transform to player transform
        playerTransform.parent = player.transform;
    }

    public void GetUpAtAnimationEnd()
    {
        // TODO
    }

    public override void DisplayText()
    {
        this.interactText.enabled = true;
        this.interactText.text = "Press " + this.interactKey.ToString() + " to " 
            + (objectUsed ? STAND_UP : SIT_DOWN) + " " + this.name;
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
