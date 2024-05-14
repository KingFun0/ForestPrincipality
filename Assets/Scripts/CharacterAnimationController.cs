using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{

    Animator animator;
    Rigidbody rb;
    public float moveSpeed = 5f;
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        bool isRunning = movement.magnitude > 0f;

        animator.SetBool("IsRunning", isRunning);

        if (isRunning)
        {
            Vector3 moveDirection = Camera.main.transform.TransformDirection(movement);

            moveDirection.y = 0f;

            rb.velocity = moveDirection * moveSpeed;
           
          
        }
        else
        {

            rb.velocity = Vector3.zero;
        }
    }
}
