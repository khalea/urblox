using System.Collections;
using System.Collections.Generic;
using Valve.VR;
using UnityEngine;

public class LaserGrab : MonoBehaviour
{
    public Transform cameraRigTransform;
    public Transform headTransform; // The camera rig's head

    public SteamVR_Input_Sources handType;
    public SteamVR_Behaviour_Pose controllerPose;
    public SteamVR_Action_Boolean TeleportAction;

    public GameObject laserPrefab; // The laser prefab
    private GameObject laser; // A reference to the spawned laser
    private Transform laserTransform; // The transform component of the laser for ease of use
    private Vector3 hitPoint; // Point where the raycast hits
    public GameObject grabbable;

    public GameObject teleportReticlePrefab; // Stores a reference to the teleport reticle prefab.
    private GameObject reticle; // A reference to an instance of the reticle
    private Transform teleportReticleTransform; // Stores a reference to the teleport reticle transform for ease of use

    private bool shouldTeleport; // True if there's a valid teleport target
    public SteamVR_Action_Boolean grabAction;

    private GameObject collidingObject; // 1
    private GameObject objectInHand; // 2

    //private void SetCollidingObject(Collider col)
    //{
    //    // 1
    //    if (collidingObject || !col.GetComponent<Rigidbody>())
    //    {
    //        return;
    //    }
    //    // 2
    //    collidingObject = col.gameObject;
    //}

    //// 1
    //public void OnTriggerEnter(Collider other)
    //{
    //    SetCollidingObject(other);
    //}

    //// 2
    //public void OnTriggerStay(Collider other)
    //{
    //    SetCollidingObject(other);
    //}

    //// 3
    //public void OnTriggerExit(Collider other)
    //{
    //    if (!collidingObject)
    //    {
    //        return;
    //    }

    //    collidingObject = null;
    //}

    private void GrabObject()
    {
        // 1
        objectInHand = grabbable;
        grabbable = null;
        // 2
        var joint = AddFixedJoint();
        joint.connectedBody = objectInHand.GetComponent<Rigidbody>();
    }

    // 3
    private FixedJoint AddFixedJoint()
    {
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.breakForce = 20000;
        fx.breakTorque = 20000;
        return fx;
    }

    private void ReleaseObject()
    {
        // 1
        if (GetComponent<FixedJoint>())
        {
            // 2
            GetComponent<FixedJoint>().connectedBody = null;
            Destroy(GetComponent<FixedJoint>());
            // 3
            objectInHand.GetComponent<Rigidbody>().velocity = -1 * controllerPose.GetVelocity();
            objectInHand.GetComponent<Rigidbody>().angularVelocity = -1 * controllerPose.GetAngularVelocity();

        }
        // 4
        objectInHand = null;
    }


   
    void Start()
    {
        // 1
        laser = Instantiate(laserPrefab);
        // 2
        laserTransform = laser.transform;

    }

    void Update()
    {
        //// 1
        //if (teleportAction.GetState(handType))
        //{
        RaycastHit hit;

        if (TeleportAction.GetState(SteamVR_Input_Sources.Any))
            laser.SetActive(false);

        // 2
        if (Physics.Raycast(controllerPose.transform.position, transform.forward, out hit, 100) && !TeleportAction.GetState(SteamVR_Input_Sources.Any))
        {
            grabbable = hit.transform.gameObject;
            if ((grabbable.GetComponent("Throwable")) != null)
            {
                print(grabbable);
            }
            else
            {
                grabbable = null;
            }
            hitPoint = hit.point;
            ShowLaser(hit);
        }  

        ShowLaser(hit);

        // 1
        if (grabAction.GetLastStateDown(handType))
        {
            if (grabbable)
            {
                print(grabbable);
                GrabObject();
            }
        }

        // 2
        if (grabAction.GetLastStateUp(handType))
        {
            if (objectInHand)
            {
                ReleaseObject();
            }
        }
        //}
        //else // 3
        //{
        //    laser.SetActive(false);
        //}

    }

    private void ShowLaser(RaycastHit hit)
    {
        // 1
        laser.SetActive(true);
        // 2
        laserTransform.position = Vector3.Lerp(controllerPose.transform.position, hitPoint, .5f);
        // 3
        laserTransform.LookAt(hitPoint);
        // 4
        laserTransform.localScale = new Vector3(laserTransform.localScale.x,
                                                laserTransform.localScale.y,
                                                hit.distance);
    }


    //new
    //void Start()
    //{
    //    laser = Instantiate(laserPrefab);
    //    laserTransform = laser.transform;
    //    reticle = Instantiate(teleportReticlePrefab);
    //    teleportReticleTransform = reticle.transform;
    //}

    //void Update()
    //{
    //    // Is the touchpad held down?
    //    if (teleportAction.GetState(handType))
    //    {
    //        RaycastHit hit;

    //        // Send out a raycast from the controller
    //        if (Physics.Raycast(controllerPose.transform.position, transform.forward, out hit, 100, teleportMask))
    //        {
    //            hitPoint = hit.point;

    //            ShowLaser(hit);

    //            //Show teleport reticle
    //            reticle.SetActive(true);
    //            teleportReticleTransform.position = hitPoint + teleportReticleOffset;

    //            shouldTeleport = true;
    //        }
    //    }
    //    else // Touchpad not held down, hide laser & teleport reticle
    //    {
    //        laser.SetActive(false);
    //        reticle.SetActive(false);
    //    }

    //    // Touchpad released this frame & valid teleport position found
    //    if (teleportAction.GetStateUp(handType) && shouldTeleport)
    //    {
    //        Teleport();
    //    }
    //}

    //private void ShowLaser(RaycastHit hit)
    //{
    //    laser.SetActive(true); //Show the laser
    //    laserTransform.position = Vector3.Lerp(controllerPose.transform.position, hitPoint, .5f); // Move laser to the middle between the controller and the position the raycast hit
    //    laserTransform.LookAt(hitPoint); // Rotate laser facing the hit point
    //    laserTransform.localScale = new Vector3(laserTransform.localScale.x, laserTransform.localScale.y,
    //        hit.distance); // Scale laser so it fits exactly between the controller & the hit point
    //}

    //private void Teleport()
    //{
    //    shouldTeleport = false; // Teleport in progress, no need to do it again until the next touchpad release
    //    reticle.SetActive(false); // Hide reticle
    //    Vector3 difference = cameraRigTransform.position - headTransform.position; // Calculate the difference between the center of the virtual room & the player's head
    //    difference.y = 0; // Don't change the final position's y position, it should always be equal to that of the hit point

    //    cameraRigTransform.position = hitPoint + difference; // Change the camera rig position to where the the teleport reticle was. Also add the difference so the new virtual room position is relative to the player position, allowing the player's new position to be exactly where they pointed. (see illustration)
    //}
}
