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
        
        float move = Input.GetAxis("Vertical") * speed;
        
        float rotate = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;

        
        transform.Rotate(0, rotate, 0);

        
        Vector3 movement = transform.forward * move * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
    }
}