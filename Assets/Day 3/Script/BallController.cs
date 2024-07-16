using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D rigidBody2D;

    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        ReleaseBall();
    }

    private void ReleaseBall()
    {
        float x = UnityEngine.Random.Range(0, 2) == 0 ? -1 : 1;
        float y = UnityEngine.Random.Range(0, 2) == 0 ? -1 : 1;
        Vector2 direction = new Vector2(x, y).normalized;
        rigidBody2D.velocity = direction * speed;
    }
}
