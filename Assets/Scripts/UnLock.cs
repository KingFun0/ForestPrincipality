using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnLock : MonoBehaviour
{
    public GameObject objectToWatch;
    public GameObject objectToHide;

    private void Update()
    {
        if (objectToWatch == null)
        {
            if (objectToHide != null)
            {
                objectToHide.SetActive(true);
            }
        }
    }
}
