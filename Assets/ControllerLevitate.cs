using System.Collections;
using System.Collections.Generic;
using Valve.VR;
using UnityEngine;

public class ControllerLevitate : MonoBehaviour
{
    public SteamVR_Action_Boolean PullOutAction;
    public SteamVR_Action_Boolean PullInAction;
    public GameObject LeftController;
    public GameObject RightController;
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;
    Vector3 originalRight;
    // Start is called before the first frame update
    void Start()
    {
        originalRight = RightController.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (PullOutAction.GetStateDown(SteamVR_Input_Sources.RightHand))
        {
            //Vector3 target = (Vector3.forward * 50f);
            //RightController.transform.position = Vector3.SmoothDamp(transform.position, target, ref velocity, smoothTime);
            RightController.transform.Translate(Vector3.forward * 2f);
        }
        if (PullInAction.GetStateDown(SteamVR_Input_Sources.RightHand))
        {
            RightController.transform.position = originalRight;
        }
    }
}
