using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
[RequireComponent(typeof(ARAnchorManager))]
[RequireComponent(typeof(ARPlaneManager))]
public class ReferencePointManager : MonoBehaviour
{

    private ARRaycastManager arRaycastManager;

    private ARAnchorManager arReferencePointManager;

    private ARPlaneManager arPlaneManager;

    private List<ARAnchor> referencePoints = new List<ARAnchor>();

    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    public GameObject CursorPrefab;
    public GameObject Cursor;

    void Awake() 
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
        arReferencePointManager = GetComponent<ARAnchorManager>();
        arPlaneManager = GetComponent<ARPlaneManager>();

        //create cursor
        Cursor = Instantiate(Cursor, new Vector3(0, 0, 0), Quaternion.identity);
    }

    void Update()
    {
        //1 - Show cursor


        if (arRaycastManager.Raycast(new Vector2(0,0) , hits, TrackableType.PlaneWithinPolygon))
        {
            //get position to create the anchor
            Pose hitPose = hits[0].pose;
            //Change cursor position to "hitpos"
            Cursor.transform.position = hitPose.position;
        }

        //2 - Place Anchor ( blueprint / Grid to build )

        //3 - stop this script





        //si pas d'appuye detecté a l ecran
        if (Input.touchCount == 0)
            return;
       
        //reset touch input
        Touch touch = Input.GetTouch(0);

        //Si deplacement du doigt sur l ecran
        if(touch.phase != TouchPhase.Began)
            return;

        if(arRaycastManager.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon))
        {
            //get position to create the anchor
            Pose hitPose = hits[0].pose;
            //add the anchor to the list
            ARAnchor referencePoint = arReferencePointManager.AddAnchor(hitPose);
        }       
    }
    

}
