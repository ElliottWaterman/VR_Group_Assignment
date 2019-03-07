using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorUsable : UsableObject
{
    private DoorColliderTrigger doorTrigger;
    private Animator animator;

    // Use this for initialization
    void Start ()
    {
        doorTrigger = GetComponentInParent<DoorColliderTrigger>();
        animator = GetComponentInParent<Animator>();
    }

    private void DoorAnimationControl(string direction)
    {
        animator.SetTrigger(direction);
    }

    public override void OnUse()
    {
        // Check collider box in door trigger
        bool playerEntered = doorTrigger.HasPlayerEntered();

        // Door open state has now moved to UsableObject class as objectUsed
        //bool doorOpen = doorTrigger.IsDoorOpen();

        // Door is CLOSED, player is present and pressed E
        if (playerEntered && !objectUsed)
        {
            this.ToggleObjectUsed();

            // Set open door function not needed as state is not used see doorOpen above
            doorTrigger.SetDoorOpen(objectUsed);
            DoorAnimationControl(OPEN_STRING);
        }
        // Door is OPEN, player is present and pressed E
        else if (playerEntered && objectUsed)
        {
            this.ToggleObjectUsed();

            // Set open door function not needed as state is not used see doorOpen above
            doorTrigger.SetDoorOpen(objectUsed);
            DoorAnimationControl(CLOSE_STRING);
        }
    }

    public override void DisplayText()
    {
        this.interactText.enabled = true;
        this.interactText.text = "Press " + this.interactKey.ToString() + " to " 
            + (objectUsed ? CLOSE_STRING : OPEN_STRING) + " " + this.name;
    }
}
