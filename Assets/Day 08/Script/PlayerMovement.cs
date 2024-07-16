using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public float rotationSpeed = 100f;
    private Animator animator;
    private GameOverManager overManager;
    
    void Awake()
    {
        animator = GetComponent<Animator>();
        overManager = GameObject.Find("GameOver Manager").GetComponent<GameOverManager>();
    }

   
    void FixedUpdate()
    {
        MovePlayer();
        RotateTowardMouse();
    }

    private void MovePlayer()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Apply the movement to the player position
        transform.position += transform.right * moveVertical * speed * Time.fixedDeltaTime;
        transform.position += transform.up * moveHorizontal * speed * Time.fixedDeltaTime;

        //Restrict the player movement within the camera bounds
        transform.position = ClampPositionToCameraBounds(transform.position);

        animator.SetFloat("moveDir", moveVertical);
    }

    private Vector3 ClampPositionToCameraBounds(Vector3 position)
    {
        // Get the main camera
        Camera mainCamera = Camera.main;

        // Get the camera bounds in the world cordinates
        float camHeight = mainCamera.orthographicSize;
        float camWidht = mainCamera.aspect * camHeight;

        // Calculate the minimum and maximum bounds
        float minX = mainCamera.transform.position.x - camWidht;
        float maxX = mainCamera.transform.position.x + camWidht;
        float minY = mainCamera.transform.position.y - camHeight;
        float maxY = mainCamera.transform.position.y + camHeight;

        // Clamp the player position within the bounds
        position.x = Mathf.Clamp(position.x, minX, maxX);
        position.y = Mathf.Clamp(position.y, minY, maxY);

        return position;
    }

    private void RotateTowardMouse()
    {

        Vector3 mouseScreenPosition = Input.mousePosition; // Get the mouse position in screen coodinates
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition); // Convert the mouse position to world coordinates
        mouseWorldPosition.z = transform.position.z; // Set the Z position to be the same as the player to avoid incorrect depth calculation
        Vector3 direction = mouseWorldPosition - transform.position;  // Calculate the direction from the player to the mouse

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;   // Calculate the angle required to rotate towards the mouse

        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            overManager.GameOver();
            Debug.Log("Collide the Player");
        }
    }
}
