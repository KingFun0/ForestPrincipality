using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour
{
    public void SceneNew(int id)
    {
        Load.SetSceneID(id);
    }
    public void Loaded(int level)
    {
        SceneManager.LoadScene(level);
    }
}
