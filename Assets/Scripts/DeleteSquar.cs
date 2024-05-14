using UnityEngine;
using TMPro;
using System;
using HutongGames.PlayMaker.Actions;
using Unity.VisualScripting;
public class DeleteSquar : MonoBehaviour
{
    public int territoryResourcesTexts1;
    public int territoryResourcesTexts2;
    public int territoryResourcesTexts3;
    public int territoryResourcesTexts4;
    public Sprite greenImage;
    public Sprite redImage;
    public SpriteRenderer myRender;
    private void OnMouseDown()
    {
        if (PlayerResources.Tree >= territoryResourcesTexts1 && 
            PlayerResources.Gold >= territoryResourcesTexts2 &&
            PlayerResources.Lazur >= territoryResourcesTexts3 &&
            PlayerResources.Rubi >= territoryResourcesTexts4)
        {
            if (gameObject.CompareTag("Square8"))
            {
                GameObject objectToDelete = GameObject.Find("Musor");
                Destroy(objectToDelete);
            }
            if (gameObject.CompareTag("Square6"))
            {
                GameObject objectToDelete = GameObject.Find("Musor2");
                Destroy(objectToDelete);
            }
            if (gameObject.CompareTag("Square7"))
            {
                GameObject objectToDelete = GameObject.Find("Musor1");
                Destroy(objectToDelete);
            }
            int value = PlayerResources.Tree - territoryResourcesTexts1;
            int value2 = PlayerResources.Gold - territoryResourcesTexts2;
            int value3 = PlayerResources.Lazur - territoryResourcesTexts3;
            int value4 = PlayerResources.Rubi - territoryResourcesTexts4;
            
            PlayerResources.Tree = value;
            PlayerResources.Gold = value2;
            PlayerResources.Lazur = value3;
            PlayerResources.Rubi = value4;

        }
    }
    private void Update()
    {
        if (PlayerResources.Tree >= territoryResourcesTexts1 && PlayerResources.Gold >= territoryResourcesTexts2 && PlayerResources.Lazur >= territoryResourcesTexts3 && PlayerResources.Rubi >= territoryResourcesTexts4)
        {
            myRender.sprite = greenImage;
        }
        else
        {
            myRender.sprite = redImage;
        }
    }
}
