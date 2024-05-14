using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.UI;
using TMPro;

public class CorrectMoneys : MonoBehaviour
{
    public Image image;
    public Sprite imageCorrect;
    public Sprite imageIncorrect;
    public Button button;
    public void Update()
    {
        if(PlayerResources.Tree >= 300 && PlayerResources.Gold >= 150 &&
            PlayerResources.Lazur >= 50 && PlayerResources.Rubi >= 20)
        {
            image.sprite = imageCorrect;
            button.enabled = true;
        }
        else
        {
            image.sprite = imageIncorrect;
            button.enabled = false;
        }
    }
}
