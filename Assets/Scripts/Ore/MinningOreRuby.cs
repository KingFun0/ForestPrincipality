using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinningOreRuby : MonoBehaviour
{
    public int increaseRate = 1; // Скорость увеличения золота в единицах в секунду
    public Canvas goldCanvas;
    private void Start()
    {
        // Запускаем корутину для увеличения золота каждые 20 секунд
        StartCoroutine(IncreaseGold());
    }

    IEnumerator IncreaseGold()
    {
        while (true)
        {
            yield return new WaitForSeconds(60f);
            Debug.Log("+1 Ruby");
            PlayerResources.Rubi += increaseRate;
            goldCanvas.gameObject.SetActive(true);
            yield return new WaitForSeconds(2f);
            goldCanvas.gameObject.SetActive(false);
        }
    }
}
