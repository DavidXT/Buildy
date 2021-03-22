using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    //-----------
    //Variables :
    [Header("Sound")]
    public GameObject SoundManager;

    //Tab Button
    [Header("Tab Button")]
    public GameObject WallButton;
    public GameObject DoorButton;
    public GameObject WindowButton;
    public GameObject RoofButton;
    public GameObject RotationButton;
    public GameObject TrashButton;

    //Tab Background
    [Header("Tab Background")]
    public GameObject WallBackground;
    public GameObject DoorBackground;
    public GameObject WindowBackground;
    public GameObject RoofBackground;
    public GameObject TrashBackground;

    //Selectors
    [Header("Selectors")]
    public GameObject WallSelector;
    public GameObject DoorSelector;
    public GameObject WindowSelector;
    public GameObject RoofSelector;
    public GameObject RotationSelector;
    public GameObject TrashSelector;

    //Texture trash
    [Header("Textures Trash")]
    public Sprite TrashClosed;
    public Sprite TrashOpen;

    //Texture Rotation
    [Header("Textures Rotation")]
    public Sprite RotationDefault;
    public Sprite RotationSelected;

    //texture Sound
    [Header("Textures Sound")]
    public Sprite SoundOn;
    public Sprite SoundOff;
    private bool bSoundIsActive = true;

    //Default Button Texture
    [Header("Default Button Texture")]
    public Sprite DefaultWallTexture;
    public Sprite DefaultDoorTexture;
    public Sprite DefaultWindowTexture;
    public Sprite DefaultRoofTexture;


    //Selected Button Texture
    [Header("Selected Button Texture")]
    public Sprite SelectedWallTexture;
    public Sprite SelectedDoorTexture;
    public Sprite SelectedWindowTexture;
    public Sprite SelectedRoofTexture;

    //Menu to hide / display
    [Header("In game Menu")]
    public GameObject Menu;

    //Menu Buttons
    [Header("Menu Buttons")]
    public GameObject ReturnButton;
    public GameObject SoundButton;
    public GameObject PictureButton;


    // Start is called before the first frame update
    void Start()
    {
        //get sound Manager
        SoundManager = GameObject.Find("SoundManager");

        //set default
        bSoundIsActive = !SoundManager.GetComponent<SoundManager>().Music.mute;

        //default active 
        SelectWall();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClicButton()
    {
        SoundManager.GetComponent<SoundManager>().PlayButtonSound();
    }

    public void ResetUi()
    {
        //change background color to default (white)
        WallBackground.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        DoorBackground.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        WindowBackground.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        RoofBackground.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        TrashBackground.GetComponent<Image>().color = new Color32(255, 255, 255, 255);

        //change button color to default
        WallButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        DoorButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        WindowButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        RoofButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        TrashButton.GetComponent<Image>().color = new Color32(255, 93, 93, 255); //red for the trash

        //change button textures to default
        WallButton.GetComponent<Image>().sprite = DefaultWallTexture;
        DoorButton.GetComponent<Image>().sprite = DefaultDoorTexture;
        WindowButton.GetComponent<Image>().sprite = DefaultWindowTexture;
        RoofButton.GetComponent<Image>().sprite = DefaultRoofTexture;
        RotationButton.GetComponent<Image>().sprite = RotationDefault;
        TrashButton.GetComponent<Image>().sprite = TrashClosed;

        //change Sound button texture to default
        if (bSoundIsActive)
        {
            SoundButton.GetComponent<Image>().sprite = SoundOn;
        }
        else
        {
            SoundButton.GetComponent<Image>().sprite = SoundOff;
        }


        WallSelector.SetActive(false);
        DoorSelector.SetActive(false);
        WindowSelector.SetActive(false);
        RoofSelector.SetActive(false);
        RotationSelector.SetActive(false);
        TrashSelector.SetActive(false);
    }


    //----------------------
    //selections fonctions :

    public void SelectWall()
    {
        //play sound
        ClicButton();
        //reset UI
        ResetUi();
        //change color to display wich one is selected
        //WallBackground.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
        //change texture to display wich one is selected
        WallButton.GetComponent<Image>().sprite = SelectedWallTexture;
        //Show matching Selector
        WallSelector.SetActive(true);
    }

    public void SelectDoor()
    {
        //play sound
        ClicButton();
        //reset UI
        ResetUi();
        //change color to display wich one is selected
        //DoorBackground.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
        //change texture to display wich one is selected
        DoorButton.GetComponent<Image>().sprite = SelectedDoorTexture;
        //Show matching Selector
        DoorSelector.SetActive(true);
    }


    public void SelectWindow()
    {
        //play sound
        ClicButton();
        //reset UI
        ResetUi();
        //change color to display wich one is selected
        //WindowBackground.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
        //change texture to display wich one is selected
        WindowButton.GetComponent<Image>().sprite = SelectedWindowTexture;
        //Show matching Selector
        WindowSelector.SetActive(true);
    }

    public void SelectRoof()
    {
        //play sound
        ClicButton();
        //reset UI
        ResetUi();
        //change color to display wich one is selected
        //RoofBackground.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
        //change texture to display wich one is selected
        RoofButton.GetComponent<Image>().sprite = SelectedRoofTexture;
        //Show matching Selector
        RoofSelector.SetActive(true);
    }

    public void SelectRotation()
    {
        //play sound
        ClicButton();
        //reset UI
        ResetUi();
        //change picture to selected
        RotationButton.GetComponent<Image>().sprite = RotationSelected;

        //Show matching Selector
        RotationSelector.SetActive(true);
    }

    public void SelectTrash()
    {
        //play sound
        ClicButton();
        //reset UI
        ResetUi();
        //change color to display wich one is selected
        //TrashBackground.GetComponent<Image>().color = new Color32(200, 200, 200, 255);

        //change picture to "open trahs"
        TrashButton.GetComponent<Image>().sprite = TrashOpen;

        //Show matching Selector
        TrashSelector.SetActive(true);
    }

    //--------------
    //Menu fonctions

    public void ToggleMenu()
    {
        //play sound
        ClicButton();
        //hide or display menu
        Menu.SetActive(!Menu.activeSelf);
    }

    public void LoadMainMenu()
    {
        //play sound
        ClicButton();
        //change scene
        SceneManager.LoadScene("Menu");
    }

    public void ToggleSound()
    {
        //play sound
        ClicButton();

        //toggle sound
        bSoundIsActive = !bSoundIsActive;

        //change SoundButton picture
        if (bSoundIsActive)
        {
            SoundButton.GetComponent<Image>().sprite = SoundOn;
        }
        else
        {
            SoundButton.GetComponent<Image>().sprite = SoundOff;
        }

        SoundManager.GetComponent<SoundManager>().ToggleSound();
    }

    public void TakePicture()
    {
        //play sound
        ClicButton();
    }
}
