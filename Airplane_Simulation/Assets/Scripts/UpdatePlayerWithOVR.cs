using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatePlayerWithOVR : MonoBehaviour
{
    float m_deadTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Primary thumbstick is left hand
        Vector2 touchAxisLeft = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick) * Time.deltaTime;
        transform.position += new Vector3(touchAxisLeft.x, 0, touchAxisLeft.y);

        // Secondary thumbstick is right hand
        Vector2 touchAxisRight = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick) * Time.deltaTime;
        transform.position += new Vector3(touchAxisRight.x, 0, touchAxisRight.y);

        //if (OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger) && m_deadTime <= 0)
        //{
        //    GameObject bullet = Instantiate<GameObject>(Bullet);
        //    GameObject fireStart = transform.FindChild("FireStart").gameObject;
        //    bullet.transform.position = fireStart.transform.position;
        //    bullet.transform.rotation *= fireStart.transform.rotation;
        //    bullet.GetComponent<Rigidbody>().AddForce(fireStart.transform.right * 2.85f, ForceMode.Impulse);
        //    GetComponent<AudioSource>().Play();
        //    m_deadTime = DeadTime;
        //}
    }
}
