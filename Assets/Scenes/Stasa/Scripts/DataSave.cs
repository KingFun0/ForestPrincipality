using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSave : MonoBehaviour
{
    public  string objectName;
    public int id;

    public void saveInt()
    {
        PlayerPrefs.SetInt (objectName, id);
    }

}
