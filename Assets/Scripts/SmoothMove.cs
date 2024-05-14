using UnityEngine;

public class SmoothMove : MonoBehaviour
{
    private float speed = 1.25f;
    private float distance = 0.5f;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float newY = Mathf.Sin(Time.time * speed) * distance + startPosition.y;
        Vector3 newPosition = new Vector3(transform.position.x, newY, transform.position.z);

        transform.position = newPosition;
    }
}
