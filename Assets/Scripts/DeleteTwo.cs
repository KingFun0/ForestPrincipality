using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeleteTwo : MonoBehaviour
{
    public int territoryResourcesTexts1;
    public int territoryResourcesTexts2;
    public Sprite greenImage;
    public Sprite redImage;
    public SpriteRenderer myRender;
    private void OnMouseDown()
    {
        if (PlayerResources.Tree >= territoryResourcesTexts1 &&
           PlayerResources.Gold >= territoryResourcesTexts2)
        {
            if (gameObject.CompareTag("Square2"))
            {
                GameObject objectToDelete = GameObject.Find("Musor6");
                Destroy(objectToDelete);
            }
            if (gameObject.CompareTag("Square"))
            {
                GameObject objectToDelete = GameObject.Find("Musor7");
                Destroy(objectToDelete);
            }
            int value = PlayerResources.Tree - territoryResourcesTexts1;
            int value2 = PlayerResources.Gold - territoryResourcesTexts2;

            PlayerResources.Tree = value;
            PlayerResources.Gold = value2;

        }


    }
    private void Update()
    {
        if(PlayerResources.Tree >= territoryResourcesTexts1 && PlayerResources.Gold >= territoryResourcesTexts2)
        {
            myRender.sprite = greenImage;
        }
        else
        {
            myRender.sprite = redImage;
        }
    }
           
}
