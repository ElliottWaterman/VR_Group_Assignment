using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttendentButton : UsableObject
{
    public AudioSource Source;
    public AudioClip AttendentSound;
    public GameObject player;

    private bool playerEntered = false;
    private string oldInteractText;

    // Use this for initialization
    void Start()
    {
        // Get player and light components
        if (player == null) player = GameObject.FindGameObjectWithTag("Player");

        if (player == null)
        {
            Debug.LogError("Player not found.");
            //Destroy(this);
        }

        // Set buttons and keys (overriding that in UsableObject class)
        interactButton = OVRInput.Button.Three;
        interactKey = KeyCode.X;
    }

    void Update()
    {
        // Check player is near the seat
        if (playerEntered && this.isInputPressed())
        {
            // Use the object
            Source.PlayOneShot(AttendentSound);
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
        string lightText = "Press " + this.interactKey.ToString() + " to call Attendant" + "\n";
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
