using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    public float paddleSpeed;
    private float controller;
    public bool playerOne;
    public float yBoundary;

    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        PaddleMovement();
    }

    private void PaddleMovement()
    {
        if (playerOne)
            controller = Input.GetAxis("Vertical");
        else
            controller = Input.GetAxis("Vertical2");

        rigidBody2D.velocity = new Vector2(0, controller * paddleSpeed);

        // Clamp the paddls position within the screen bound
        Vector3 clampPosition = transform.position;
        clampPosition.y = Mathf.Clamp(clampPosition.y, -yBoundary, yBoundary);
        transform.position = clampPosition;

    }
}
