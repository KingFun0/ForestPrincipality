using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MinningOre : MonoBehaviour
{

    public int increaseRate = 1; // �������� ���������� ������ � �������� � �������
    public Canvas goldCanvas;
    private void Start()
    {
        // ��������� �������� ��� ���������� ������ ������ 20 ������
        StartCoroutine(IncreaseGold());
    }

    IEnumerator IncreaseGold()
    {
        while (true)
        {
            yield return new WaitForSeconds(20f); 
            Debug.Log("+1 Gold");
            PlayerResources.Gold += increaseRate;
            goldCanvas.gameObject.SetActive(true);
            yield return new WaitForSeconds(2f);
            goldCanvas.gameObject.SetActive(false);
        }
    }
}
