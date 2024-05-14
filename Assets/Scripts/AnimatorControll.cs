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
        // Проверяем, находится ли персонаж на объекте с тегом "ResourceMarker"
        if (isOnResourceMarker)
        {
            ChangeAnimation("Runtoslide");
        }
        else
        {
            // Если персонаж не находится на объекте с тегом "ResourceMarker", воспроизводим анимации "Run" или "Idle"
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
