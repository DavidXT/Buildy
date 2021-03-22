using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoovingBackground : MonoBehaviour
{
    private Image rend;
    float scrollSpeed = 0.03f;

    void Start()
    {
        rend = GetComponent<Image>();
        //Debug.Log("Screen Width : " + Screen.width);

        //set Tilling depending of screen size
        //float scaleX = (float)Screen.width / 2160.0f;

        //float scaleX = (float)Screen.width / (float)Screen.height;
        //float scaleY = 1;

        //change size of the background (Tilling)
        float scaleX = (float)Screen.width / 3840.0f;
        float scaleY = (float)Screen.height / 2160.0f;
        rend.material.SetTextureScale("_MainTex", new Vector2(scaleX, scaleY));


    }


    void Update()
    {
        //create moovement (Offset)
        float offset = Time.time * scrollSpeed;
        rend.material.SetTextureOffset("_MainTex", new Vector2(0, offset));
    }
}
