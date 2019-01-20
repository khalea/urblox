using Valve.VR;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePlacer : MonoBehaviour
{
    private Grid grid;

    public SteamVR_Input_Sources handType;
    public SteamVR_Behaviour_Pose controllerPose;
    public SteamVR_Action_Boolean grabAction;

    public GameObject laserPrefab; // The laser prefab
    private GameObject laser; // A reference to the spawned laser
    private Transform laserTransform; // The transform component of the laser for ease of use
    private Vector3 hitPoint; // Point where the raycast hits

    private GameObject collidingObject; // 1
    private GameObject objectInHand; // 2

    private void Awake()
    {
        grid = FindObjectOfType<Grid>();
    }

    private void Update()
    {
        if (grabAction.GetState(handType))
        {
            //RaycastHit hitInfo;
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;


            if (Physics.Raycast(controllerPose.transform.position, transform.forward, out hit, 100))
            {
                hitPoint = hit.point;
                PlaceCubeNear(hit.point);
            }

            //if (Physics.Raycast(ray, out hitInfo))
            //{
            //    PlaceCubeNear(hitInfo.point);
            //}
        }
    }

    private void PlaceCubeNear(Vector3 clickPoint)
    {
        var finalPosition = grid.GetNearestPointOnGrid(clickPoint);
        GameObject.CreatePrimitive(PrimitiveType.Cube).transform.position = finalPosition;

        //GameObject.CreatePrimitive(PrimitiveType.Sphere).transform.position = nearPoint;
    }
}