using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwithcJust : MonoBehaviour
{
    public void OpenScene(int sceneId)
    {
        SceneManager.LoadScene(sceneId);
    }
}
