using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideCanvases : MonoBehaviour
{
    public GameObject canvas1;
    public GameObject canvas2;

    public void HideCanvasess()
    {
        canvas1.SetActive(false);
        canvas2.SetActive(false);
    }
}
