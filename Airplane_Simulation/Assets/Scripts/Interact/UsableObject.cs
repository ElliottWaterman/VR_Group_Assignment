using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UsableObject : MonoBehaviour
{
    protected const string OPEN_STRING = "Open";
    protected const string CLOSE_STRING = "Close";
    protected const string ON_STRING = "On";
    protected const string OFF_STRING = "Off";

    public Text interactText;

    // Default interact button
    // Set new interact input in child script start function
    protected OVRInput.Button interactButton = OVRInput.Button.One;
    protected KeyCode interactKey = KeyCode.E;

    protected bool objectUsed = false;

    public virtual void OnUse()
    {
        // Cant do specific action here so new "objUsable" script always needs to be created
    }


    public virtual void DisplayText()
    {
        // Default interact text
        this.interactText.enabled = true;
        this.interactText.text = "Press " + interactKey.ToString() + " to interact with " + this.gameObject.name;
    }

    public void HideText()
    {
        this.interactText.enabled = false;
    }

    public OVRInput.Button GetInteractButton()
    {
        return this.interactButton;
    }
    public KeyCode GetInteractKey()
    {
        return this.interactKey;
    }

    public Boolean isInputPressed()
    {
        if (OVRInput.GetDown(this.interactButton) || Input.GetKeyDown(this.interactKey))
        {
            return true;
        }
        return false;
    }

    protected void ToggleObjectUsed()
    {
        objectUsed = !objectUsed;
    }
}
