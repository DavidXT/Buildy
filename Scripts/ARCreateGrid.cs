using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.Experimental.XR;
using System;

public class ARCreateGrid : MonoBehaviour
{
    public GameObject objectToPlace;
    public GameObject placementIndicator;
    public GameObject crossIndicator;

    private ARRaycastManager arOrigin;
    private Pose placementPose;
    private bool placementPoseIsValid = false;

    private bool bIsGridCreated = false;

    void Start()
    {
        arOrigin = FindObjectOfType<ARRaycastManager>();

    }

    void Update()
    {
        //dont do anything if the anchor is already created
        if (!bIsGridCreated)
        {
            UpdatePlacementPose();
            UpdatePlacementIndicator();

            //if (placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            //{
            //    PlaceObject();
            //}
        }
    }

    public void Clic()
    {
        if (placementPoseIsValid)
        {
            PlaceObject();
        }
    }


    private void PlaceObject()
    {
        //instanciate the grid only once
        if (!bIsGridCreated)
        {
            Instantiate(objectToPlace, placementPose.position, placementPose.rotation);
            //do once
            bIsGridCreated = true;

            crossIndicator.SetActive(false);
            placementIndicator.SetActive(false);
        }
    }

    private void UpdatePlacementIndicator()
    {
        //show idicator to place anchor
        if (placementPoseIsValid)
        {
            crossIndicator.SetActive(false);
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
        }
        else
        {
            crossIndicator.SetActive(true);
            placementIndicator.SetActive(false);
        }
    }

    private void UpdatePlacementPose()
    {
        //update indicator position
        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        arOrigin.Raycast(screenCenter, hits, TrackableType.Planes);

        placementPoseIsValid = hits.Count > 0;
        if (placementPoseIsValid)
        {
            placementPose = hits[0].pose;

            var cameraForward = Camera.current.transform.forward;
            var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
            placementPose.rotation = Quaternion.LookRotation(cameraBearing);
        }
    }

}