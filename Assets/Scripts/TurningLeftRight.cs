using System.Collections;
using System.Collections.Generic;
using Valve.VR;
using UnityEngine;

public class TurningLeftRight : MonoBehaviour
{
    public SteamVR_Action_Boolean TurnLeftAction;
    public SteamVR_Action_Boolean TurnRightAction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TurnLeftAction.GetStateDown(SteamVR_Input_Sources.Any)) 
        {
            transform.Rotate(0f, -45f, 0f);
        }
        if (TurnRightAction.GetStateDown(SteamVR_Input_Sources.Any))
        {
            transform.Rotate(0f, 45f, 0f);
        }

    }
}
