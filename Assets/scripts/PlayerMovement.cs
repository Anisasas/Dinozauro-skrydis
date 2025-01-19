using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Veikėjo judėjimo greitis
    public float rotationSpeed = 720f; // Veikėjo sukimosi greitis
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
      float move = Input.GetAxis("Vertical");
      float rotate = Input.GetAxis("Horizontal");

       if (Mathf.Abs(move) > 0.1f || Mathf.Abs(rotate) > 0.1f)
      {
            transform.Rotate(0, rotate * rotationSpeed * Time.deltaTime, 0);

           Vector3 movement = transform.forward * move * speed * Time.deltaTime;
           rb.MovePosition(rb.position + movement);
        }
    }
}
