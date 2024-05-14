using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinningTree : MonoBehaviour
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
            yield return new WaitForSeconds(7f);
            Debug.Log("+1 Tree");
            PlayerResources.Tree += increaseRate;
            goldCanvas.gameObject.SetActive(true);
            yield return new WaitForSeconds(2f);
            goldCanvas.gameObject.SetActive(false);
        }
    }
}
