using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeleteThe : MonoBehaviour
{ 
    public int territoryResourcesTexts1;
    public int territoryResourcesTexts2;
    public int territoryResourcesTexts3;
    public Sprite greenImage;
    public Sprite redImage;
    public SpriteRenderer myRender;
    private void OnMouseDown()
    {
        if (PlayerResources.Tree >= territoryResourcesTexts1 &&
           PlayerResources.Gold >= territoryResourcesTexts2 &&
           PlayerResources.Lazur >= territoryResourcesTexts3)
        {
            if (gameObject.CompareTag("Square4"))
            {
                GameObject objectToDelete = GameObject.Find("Musor4");
                Destroy(objectToDelete);
            }

            if (gameObject.CompareTag("Square5"))
            {
                GameObject objectToDelete = GameObject.Find("Musor3");
                Destroy(objectToDelete);
            }
            if (gameObject.CompareTag("Square3"))
            {
                GameObject objectToDelete = GameObject.Find("Musor5");
                Destroy(objectToDelete);
            }
            int value = PlayerResources.Tree - territoryResourcesTexts1;
            int value2 = PlayerResources.Gold - territoryResourcesTexts2;
            int value3 = PlayerResources.Lazur - territoryResourcesTexts3;


            PlayerResources.Tree = value;
            PlayerResources.Gold = value2;
            PlayerResources.Lazur = value3;

        }
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

    }
    private void Update()
    {
        if(PlayerResources.Tree >= territoryResourcesTexts1 &&  PlayerResources.Gold >= territoryResourcesTexts2 && PlayerResources.Lazur >= territoryResourcesTexts3)
        {
            myRender.sprite = greenImage;
        }
        else
        {
            myRender.sprite = redImage;
        }
    }
}
