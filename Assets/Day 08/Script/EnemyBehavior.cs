using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float speed = 3.0f;
    private Transform player;
    public GameObject bloodSplat;
    public int killCount = 1;
    private ScoreManager scoreManager;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    
    void FixedUpdate()
    {
        MoveTowardPlayer();
        RotateToPlayer();
    }

    private void RotateToPlayer()
    {
        if (player == null)
            return;

        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    private void MoveTowardPlayer()
    {
        if (player == null)
            return;

        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * speed * Time.fixedDeltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            scoreManager.AddScore(killCount);
            InstantiateBloodSplat();
            Debug.Log("Collide the Enemy");
        }
    }

    private void InstantiateBloodSplat()
    {
        GameObject bloodSplates = Instantiate(bloodSplat, transform.position, transform.rotation);
        Destroy(bloodSplates, 1f);
    }
}
