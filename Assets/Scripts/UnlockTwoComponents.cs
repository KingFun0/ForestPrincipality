using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockTwoComponents : MonoBehaviour
{
    public GameObject objectToWatch;
    public GameObject objectToShow;
    public GameObject objectToShow2;

    private void Update()
    {
        if (objectToWatch == null)
        {
            if (objectToShow != null && objectToShow2 != null)
            {
                objectToShow.SetActive(true);
                objectToShow2.SetActive(true);
            }
        }
    }
}
