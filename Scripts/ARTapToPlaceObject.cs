using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.Experimental.XR;
using System;

public class ARTapToPlaceObject : MonoBehaviour
{
    public GameObject objectToPlace;
    public GameObject placementIndicatorObject;
    public Grid grid;


    private ARRaycastManager arOrigin;
    private Pose placementPose;
    private bool placementPoseIsValid = false;
    private GameObject rotate;
    private Quaternion targetRotation = Quaternion.AngleAxis(90, Vector3.up);

    private GameObject GameManager;

    void Start()
    {
        arOrigin = FindObjectOfType<ARRaycastManager>();
        grid = FindObjectOfType<Grid>();
        GameManager = GameObject.Find("GameManager");
    }

    void Update()
    {
        //Update placement indicator
        Rotation();
        UpdatePlacementPose();
        UpdatePlacementIndicator();
        placementIndicatorObject.SetActive(true);

        //Instantiate Object

        //if (placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        //{
        //    Instantiate(objectToPlace, grid.GetNearestPointOnGrid(placementPose.position), targetRotation);
        //}
    }

    //Function rotation models
    public void Rotation()
    {
        if (GameManager.GetComponent<GameManager>().bIsRotating)
        {
            //add 90° to quaternion angle
            targetRotation *= Quaternion.AngleAxis(90, Vector3.up);
            GameManager.GetComponent<GameManager>().bIsRotating = false;
        }
    }

    /* ******EN COURS******
     * Fonction pour delete un objet instancier 
     * public void Delete()
      {
          if (placementPoseIsValid)
          {
              //raycast
              var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));

              Ray ray = Camera.main.ScreenPointToRay(screenCenter);
              RaycastHit hit;

              if (Physics.Raycast(ray, out hit, 100))
              {

                  //if (hit.transform.gameObject.tag == "Wall")
                  //{ 
                  //}

                  //supprime ABSOLUMENT tout ce qui est touché par le raycast
                  Destroy(hit.transform.gameObject);
                  //Debug.DrawLine(ray.origin, hit.point);
              }

          }
      }*/

    public void Clic()
    {
        if (placementPoseIsValid)
        {
            /*if (GameManager.GetComponent<GameManager>().bIsRotating)
            {
                //delete mode
                //Delete();
            }
            else
            {*/
                //create model
                if (GameManager.GetComponent<GameManager>().CurrentPrefab != null)
                {
                    objectToPlace = GameManager.GetComponent<GameManager>().CurrentPrefab;
                }
                Instantiate(objectToPlace, grid.GetNearestPointOnGrid(placementPose.position), targetRotation);
            //}           
        }
    }

    private void UpdatePlacementIndicator()
    {
        //Update placement indicator
        placementIndicatorObject.SetActive(true);
        placementIndicatorObject.transform.SetPositionAndRotation(grid.GetNearestPointOnGrid(placementPose.position), targetRotation);
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