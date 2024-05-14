using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // ������ �� ��������� Rigidbody ������
    private Rigidbody rb;

    // �������������
    private void Start()
    {
        // �������� ��������� Rigidbody ������
        rb = GetComponent<Rigidbody>();
    }

    // ������� ����������, ����� ���������� �������� � ������ ��������
    private void OnCollisionEnter(Collision collision)
    {
        // ���������, ���� �� � ������� ��� "Wall"
        if (collision.gameObject.CompareTag("Wall"))
        {
            // ���� ����, �� ��������� �������� ���������
            Debug.Log("������������ � �������� Wall!");

            // ������������� �������� ������
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

        }
    }
}
