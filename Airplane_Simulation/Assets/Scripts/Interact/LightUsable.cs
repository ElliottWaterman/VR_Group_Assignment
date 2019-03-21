using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightUsable : UsableObject
{
    private Light overheadLight;
    public GameObject player;

    private SeatUsable seatUsableScript;
    private bool playerEntered = false;
    private string oldInteractText;

    private Transform playerTransform;

    // Use this for initialization
    void Start ()
    {
        // Get player and light components
        if(player == null) player = GameObject.FindGameObjectWithTag("Player");
        overheadLight = GetComponentInChildren<Light>();

        if (player == null)
        {
            Debug.LogError("Player not found.");
            //Destroy(this);
        }
        if (overheadLight == null)
        {
            Debug.LogError("Light child component could not be found.");
            //Destroy(this);
        }

        // Set buttons and keys (overriding that in UsableObject class)
        interactButton = OVRInput.Button.Four;
        interactKey = KeyCode.Y;

        // Get seat script in order to get box collider
        seatUsableScript = GetComponentInParent<SeatUsable>();
    }

    void Update()
    {
        // Check player is near the seat
        // TODO check if player is sitting
        if (playerEntered && this.isInputPressed())
        {
            // Use the object
            this.OnUse();
        }
    }

    public override void OnUse()
    {
        if (!objectUsed)
        {
            this.ToggleObjectUsed();
            // Turn on light
            overheadLight.enabled = true;
            // Update text to reflect the new on/off state of the light
            DisplayText();
        }
        else
        {
            this.ToggleObjectUsed();
            // Turn off light
            overheadLight.enabled = false;
            // Update text to reflect the new on/off state of the light
            DisplayText();
        }
    }

    public void StoreCurrentInteractText()
    {
        oldInteractText = this.interactText.text;
    }

    public override void DisplayText()
    {
        this.interactText.enabled = true;
        // Append light use text
        string lightText = "Press " + this.interactKey.ToString() + " to turn " 
            + (objectUsed ? OFF_STRING : ON_STRING) + " " + this.name + "\n";
        this.interactText.text = lightText + oldInteractText;
    }

    public override void HideText()
    {
        // Show previous interact text
        this.interactText.text = oldInteractText;
    }

    private void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            playerEntered = true;

            StoreCurrentInteractText();
            // Show interact text on the screen
            this.DisplayText();
        }
    }

    private void OnTriggerExit(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            playerEntered = false;

            StoreCurrentInteractText();
            // Hide interact text on the screen
            this.HideText();
        }
    }
}
