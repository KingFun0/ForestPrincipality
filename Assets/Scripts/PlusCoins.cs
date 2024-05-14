using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusCoins : MonoBehaviour
{
    // Start is called before the first frame update
   public void Buy()
    {
        PlayerResources.Coins += 1;
        PlayerResources.Tree -= 300;
        PlayerResources.Gold -= 150;
        PlayerResources.Lazur -= 50;
        PlayerResources.Rubi -= 20;
    }
}
