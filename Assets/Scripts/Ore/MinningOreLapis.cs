using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinningOreLapis : MonoBehaviour
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
            yield return new WaitForSeconds(40f);
            Debug.Log("+1 Lapis");
            PlayerResources.Lazur += increaseRate;
            goldCanvas.gameObject.SetActive(true);
            yield return new WaitForSeconds(2f);
            goldCanvas.gameObject.SetActive(false);
        }
    }
}
