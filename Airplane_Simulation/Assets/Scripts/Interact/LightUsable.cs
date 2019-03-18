using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightUsable : UsableObject
{
    private Light overheadLight;

    private bool playerEntered = false;

    // Use this for initialization
    void Start ()
    {
        overheadLight = GetComponentInChildren<Light>();

        if (overheadLight == null)
        {
            Debug.LogError("Light child component could not be found.");
        }
    }

    private void Update()
    {
        if (playerEntered)
        {
            if (this.isInputPressed())
            {
                // Use the object
                this.OnUse();

                // Also update text to display object should be closed
                this.DisplayText();
            }
        }
    }

    public override void OnUse()
    {
        // Player is present and not sat down
        if (playerEntered && !objectUsed)
        {
            this.ToggleObjectUsed();

            // Turn on light
            overheadLight.enabled = true;
        }
        // Player is present and is sat down
        else if (playerEntered && objectUsed)
        {
            this.ToggleObjectUsed();

            // Turn on light
            overheadLight.enabled = false;
        }
    }

    public override void DisplayText()
    {
        this.interactText.enabled = true;
        this.interactText.text = "Press " + this.interactKey.ToString() + " to turn " 
            + (objectUsed ? ON_STRING : OFF_STRING) + " " + this.name;
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
