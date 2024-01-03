using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using OculusSampleFramework;

public class DisplayCanvas : MonoBehaviour
{
    public Canvas canvasToDisplay;
    public void ShowCanvas()
    {
        canvasToDisplay.enabled = true;
    }
    public void HideCanvas()
    {
        canvasToDisplay.enabled = false;
    }
}



