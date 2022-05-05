using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float Speed = 0.7f;
    private Rigidbody2D rb;
    private Vector2 direction;
    private Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!PauseMenu.GameIsPaused)
        {
            float xAxis = Input.GetAxisRaw("Horizontal");
            float yAxis = Input.GetAxisRaw("Vertical");

            direction = new Vector2(xAxis, yAxis);

            animator.SetFloat("horizontal", direction.x);
            animator.SetFloat("vertical", direction.y);
            animator.SetFloat("speed", direction.sqrMagnitude);

            if (direction != Vector2.zero)
            {
                animator.SetFloat("horizontalIdle", direction.x);
                animator.SetFloat("verticalIdle", direction.y);
            }
        } 
    }

    private void FixedUpdate()
    {
        rb.MovePosition
            (rb.position +
            (direction.normalized * Speed * Time.fixedDeltaTime));
    }
}