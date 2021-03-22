using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //variables
    [Header("Current prefab")]
    public GameObject CurrentPrefab;

    //[Header("Prefab Selector Wall")]
    //public GameObject Wall1;
    //public GameObject Wall2;
    //public GameObject Wall3;
    //
    //[Header("Prefab Selector Door")]
    //public GameObject Door1;
    //public GameObject Door2;
    //public GameObject Door3;
    //
    //[Header("Prefab Selector Window")]
    //public GameObject Window1;
    //public GameObject Window2;
    //public GameObject Window3;
    //
    //[Header("Prefab Selector Roof")]
    //public GameObject Roof1;
    //public GameObject Roof2;
    //public GameObject Roof3;
    //
    //public GameObject[] TabWall;
    //public GameObject[] TabDoor;
    //public GameObject[] TabWindow;
    //public GameObject[] TabRoof;


    public GameObject ARTapToPlaceObject;
    public GameObject ARCreateGrid;

    public bool bIsRotating = false;
    public bool bIsDeleting = false;

    // Start is called before the first frame update
    void Start()
    {
        //default prefab
        //CurrentPrefab = Wall1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ResetMode()
    {
        bIsRotating = false;
        bIsDeleting = false;
    }

    public GameObject GetCurrent()
    {
        return CurrentPrefab;
    }

    public void SelectPrefab(GameObject SelectedPrefab)
    {
        ResetMode();
        CurrentPrefab = SelectedPrefab;
    }

    public void SelectRotation()
    {
        ResetMode();
        bIsRotating = true;
    }

    public void SelectTrash()
    {
        ResetMode();
        bIsDeleting = true;
    }


    public void Touch()
    {
        //if reference not assign
        if (ARTapToPlaceObject == null)
        {
            if (GameObject.Find("CreateElem"))
            {
                ARTapToPlaceObject = GameObject.Find("CreateElem");
            }
        }
        
        //if instanciate
        if (ARTapToPlaceObject != null)
        {
            //detect touch
            ARTapToPlaceObject.GetComponent<ARTapToPlaceObject>().Clic();
        }


        ARCreateGrid.GetComponent<ARCreateGrid>().Clic();
    }
        

}
