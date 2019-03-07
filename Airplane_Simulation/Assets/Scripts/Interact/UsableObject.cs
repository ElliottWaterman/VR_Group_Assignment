using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UsableObject : MonoBehaviour
{
    protected const string OPEN_STRING = "Open";
    protected const string CLOSE_STRING = "Close";

    public Text interactText;

    // Default interact button
    // Set new interact input in child script start function
    protected OVRInput.Button interactKey = OVRInput.Button.One;

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

    public OVRInput.Button GetInteractKey()
    {
        return this.interactKey;
    }

    protected void ToggleObjectUsed()
    {
        objectUsed = !objectUsed;
    }
}
