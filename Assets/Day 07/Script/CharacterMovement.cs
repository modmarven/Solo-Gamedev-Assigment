using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3.0f;

    private Rigidbody2D rigidBody;
    private Animator animator;
    private int coin;

    public float horizontal;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip coinCollectSound;
    [SerializeField] private TextMeshProUGUI coinCounter;

    [SerializeField] private float jumpForce = 7f;

    [SerializeField] private bool isGrounded;
    [SerializeField] private bool isJumping;
    



    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        coin = 0;
    }

    
    void Update()
    {      
        HandleCharacterMove();
        HandleJumpSystem();

    }

    public void HandleCharacterMove()
    {
        horizontal = Input.GetAxis("Horizontal");
        rigidBody.velocity = (Vector3.right * horizontal * moveSpeed);

        // Handling Player Animation
        animator.SetFloat("moveDir", MathF.Abs(horizontal));
    }

    private void HandleJumpSystem()
    {
        if (Input.GetKey(KeyCode.Space) && isJumping == false && isGrounded)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.y, jumpForce);
            animator.SetBool("isJumpUp", true);
        }

        if (rigidBody.velocity.y < jumpForce)
        {
            animator.SetBool("isJumpDown", true);
            animator.SetBool("isJumpUp", false);
        }

        if (isGrounded == true)
        {
            animator.SetBool("isJumpDown", false);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            PlayCollectSound();
            Destroy(collision.gameObject);
            coin += 10;
            coinCounter.text = "$" + coin.ToString();        
        }
      
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            isJumping = false;
            Debug.Log("player on the ground");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            isJumping = true;
            Debug.Log("player on the air");
        }
    }

    private void PlayCollectSound()
    {
        if (coinCollectSound != null)
        {
            audioSource.PlayOneShot(coinCollectSound);
        }
    }
}
