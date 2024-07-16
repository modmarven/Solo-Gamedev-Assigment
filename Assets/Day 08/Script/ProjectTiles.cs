using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectTiles : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 2f;

    void Awake()
    {
        Destroy(gameObject, lifeTime);
    }

    
    void FixedUpdate()
    {
        ProjectileMove();
    }

    private void ProjectileMove()
    {
        transform.Translate(Vector3.up * speed * Time.fixedDeltaTime); // Move the projectile forward
        if (!IsWithinCameraBounds())
        {
            Destroy(gameObject);
        }
    }

    private bool IsWithinCameraBounds()
    {
        Camera mainCamera = Camera.main;
        Vector3 viewPortPosition = mainCamera.WorldToViewportPoint(transform.position);

        return viewPortPosition.x >= 0 && viewPortPosition.x <= 1 && viewPortPosition.y >= 0 && viewPortPosition.y <= 1;
    }
}
