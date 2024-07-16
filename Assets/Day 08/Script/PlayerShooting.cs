using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject projectilePref;
    public Transform firePoint;
    public float fireRate = 0.5f;
    public AudioSource audioSource;
    public AudioClip fireSound;
    public Animator animator;

    private float nextFireTime = 0f;

    void Start()
    {
      
    }

    
    void FixedUpdate()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            Shoot();
            audioSource.PlayOneShot(fireSound);
            animator.SetTrigger("shoot");
        }
    }

    private void Shoot()
    {
        Instantiate(projectilePref, firePoint.position, firePoint.rotation);
    }
}
