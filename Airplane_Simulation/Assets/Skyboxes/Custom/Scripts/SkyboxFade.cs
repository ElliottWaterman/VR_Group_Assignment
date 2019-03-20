using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxFade : MonoBehaviour
{
    public Material BlendableSkyBox;
    public GameObject player;
    public Boolean DEBUG_MODE;
    public float MAX_HEIGHT;
    private float blendAmount;

    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
        {
            Debug.Log("Player not found. Attempting to use Player tag.");
            player = GameObject.FindGameObjectWithTag("Player");
            if(player == null)
            {
                Debug.LogError("Player tag not found.");
                Destroy(this);
            }

        }
        else
        {
            // Set the player equal to the instantiated  player controller (ie where the player is)
            player = player.transform.GetChild(0).gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //get player's y coords
        float ycoord = player.gameObject.transform.position.y;

        //use player coordinates to calculate how much to blend the skyboxes
        if(ycoord < 0)
        {
            //if y coord is negative, set blend amount to miniumum 
            blendAmount = 0;
        }
        else if(ycoord > MAX_HEIGHT)
        {
            //if player is above the maximum desired height for the second skybox, set blend amount to max 
            blendAmount = 1;
        }
        else
        {
            //translate player coord from being in the range (0 - MAX_HEIGHT) into a blend amount
            //in the range (0 - 1)
            blendAmount = ycoord/MAX_HEIGHT;
        }

        if(DEBUG_MODE) Debug.Log(blendAmount);

        //set the skybox _Blend variable (in its shaders) to blendAmount
        BlendableSkyBox.SetFloat("_Blend", blendAmount);

        if (DEBUG_MODE)
        {
            //move camera up and down with q and e
            if (Input.GetKey("q"))
            {
                Vector3 pos = player.gameObject.transform.position;
                pos = new Vector3(pos.x, pos.y + 5, pos.z);
                player.gameObject.transform.position = pos;
            }
            else if(Input.GetKey("e"))
            {
                Vector3 pos = player.gameObject.transform.position;
                pos = new Vector3(pos.x, pos.y - 5, pos.z);
                player.gameObject.transform.position = pos;
            }
        }
    }
}