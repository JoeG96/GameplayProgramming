using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement2 : MonoBehaviour
{
    public float moveSpeed = 100f;

    private Rigidbody body;

    private Vector3 direction;

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();

        if (direction != Vector3.zero) {
            HandleRotation();
        }
    }

    public void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        direction = new Vector3(h, 0, v);

        direction = direction.normalized;

        //CONVERT direction from local to world relative to camera
        body.velocity = Camera.main.transform.TransformDirection(direction) * moveSpeed;
    }

    public void HandleRotation()
    {
        float targetRotation = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
        Quaternion lookAt = Quaternion.Slerp(transform.rotation,
                                      Quaternion.Euler(0, targetRotation, 0),
                                      0.5f);
        body.rotation = lookAt;

    }
}
