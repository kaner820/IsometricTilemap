using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveH, moveV;
    private PlayerAnimation playerAnimation;
    public float moveSpeed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimation = FindObjectOfType<PlayerAnimation>();
    }

    private void Update()
    {
        moveH = Input.GetAxisRaw("Horizontal");
        moveV = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        Vector2 currentPos = rb.position;
        Vector2 inputVector = new Vector2(moveH, moveV).normalized * moveSpeed * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition((currentPos + inputVector));

        playerAnimation.SetDirection(new Vector2(moveH, moveV));
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.name == "Treasure")
        {
            SceneManager.LoadScene("Clear");
        }
    }
}
