using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]

    public float moveSpeed;

    public Transform orientation;

    float horizontalIn;
    float verticalIn;

    Vector3 direction;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        KeyInput();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void KeyInput()
    {
        horizontalIn = Input.GetAxisRaw("Horizontal");
        verticalIn = Input.GetAxisRaw("Vertical");
    }

    private void Move()
    {
        direction = orientation.forward * verticalIn + orientation.right * horizontalIn;
        rb.AddForce(direction.normalized * moveSpeed * 10f, ForceMode.Force);
    }
}
