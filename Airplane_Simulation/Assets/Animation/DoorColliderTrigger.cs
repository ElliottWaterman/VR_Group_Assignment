using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorColliderTrigger : MonoBehaviour {

    private UsableObject interactObject;
    private bool playerEntered;
    private bool doorOpen;

    // Use this for initialization
    void Start () {
        // Find usable object in children
        interactObject = gameObject.GetComponentInChildren<UsableObject>();
        if (interactObject == null)
        {
            Debug.LogError("Usable Object script not found in child component.");
        }

        playerEntered = false;
        doorOpen = false;
    }

    private void Update()
    {
        if (playerEntered)
        {
            if (interactObject.isInputPressed())
            {
                // Use the object
                interactObject.OnUse();

                // Also update text to display object should be closed
                interactObject.DisplayText();
            }
        }
    }

    private void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            playerEntered = true;

            if (interactObject != null)
            {
                // Show interact text on the screen
                interactObject.DisplayText();
            }
        }
    }

    private void OnTriggerExit(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            playerEntered = false;

            if (interactObject != null)
            {
                // Hide interact text on the screen
                interactObject.HideText();
            }
        }

        // Use this to close door after player has left
        if (doorOpen)
        {
            //doorOpen = false;
            //DoorAnimationControl(CLOSE_STRING);
        }
    }

    public bool HasPlayerEntered()
    {
        return this.playerEntered;
    }

    public bool IsDoorOpen()
    {
        return this.doorOpen;
    }

    public void SetDoorOpen(bool state)
    {
        this.doorOpen = state;
    }
}
