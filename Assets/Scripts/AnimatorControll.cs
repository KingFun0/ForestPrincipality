using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorControll : MonoBehaviour
{
    Animator animator;
    Rigidbody rb;
    private string currentAnimation;
    Vector3 previousPosition;
    float speed;
    bool isOnResourceMarker = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        currentAnimation = "";
        previousPosition = transform.position;
    }

    void Update()
    {
        // ���������, ��������� �� �������� �� ������� � ����� "ResourceMarker"
        if (isOnResourceMarker)
        {
            ChangeAnimation("Runtoslide");
        }
        else
        {
            // ���� �������� �� ��������� �� ������� � ����� "ResourceMarker", ������������� �������� "Run" ��� "Idle"
            Vector3 currentPosition = transform.position;
            speed = Vector3.Distance(currentPosition, previousPosition) / Time.deltaTime;
            previousPosition = currentPosition;

            if (speed > 0f && currentAnimation != "Run")
            {
                ChangeAnimation("Run");
            }
            else if (speed == 0f && currentAnimation != "Idle")
            {
                ChangeAnimation("Idle");
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ResourceMarker"))
        {
            isOnResourceMarker = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ResourceMarker"))
        {
            isOnResourceMarker = false;
        }
    }

    
    void ChangeAnimation(string animation)
    {
        animator.Play(animation);
        currentAnimation = animation;
    }
}
