using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class InfoPanelEnable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (!XRDevice.isPresent)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
    }
}
