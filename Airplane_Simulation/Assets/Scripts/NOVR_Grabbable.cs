using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NOVR_Grabbable : MonoBehaviour
{
   // public Transform holdLocation;
    private static bool grabbed;

    private void OnMouseDown()
    {
        if (!grabbed)
        {
            Debug.Log("Click On");
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Collider>().enabled = false;
            transform.parent = GameObject.Find("FirstPersonCharacter").transform;
            grabbed = true;
        }
        else {
            Debug.Log("Click Off");
            transform.parent = null;
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Collider>().enabled = true;
            grabbed = false;
        }
    }
}
