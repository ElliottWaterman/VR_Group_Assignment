using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttendentButton : UsableObject{

    private DoorColliderTrigger doorTrigger;
    private Animator animator;
    public AudioSource AttendentSound;
    private bool playerEnter;

    public void Update()
    {
        if (isInputPressed() && playerEnter) {
            OnUse();
        }
    }

    public override void OnUse()
    {
        AttendentSound.Play();
        Debug.Log("Attended Sound");
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") {

            playerEnter = true;
            DisplayText();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            playerEnter = false;
            HideText();
        }
    }

    public override void DisplayText()
    {
        this.interactText.enabled = true;
        this.interactText.text = "Press " + this.interactKey.ToString() + " for "
            + "attendence";
    }
}
