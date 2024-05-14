using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public void ChangeScens(int NumberScens)
    {
        SceneManager.LoadScene(NumberScens);
    }
    public void Exit()
{
    Application.Quit();
}
}

