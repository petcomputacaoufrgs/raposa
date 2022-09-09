using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float Speed = 0.7f;
    private Rigidbody2D rb;
    private Vector2 direction;
    private Animator animator;
    public bool Trigger = false;
    private InventorySystem inventorySystem;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        inventorySystem = GetComponent<InventorySystem>();
    }

    private void Update()
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

        if (Input.GetButtonDown("Fire1"))
        {
            Trigger = true;
        }
        else
        {
            Trigger = false;
        }

        if(Input.GetKeyDown(KeyCode.C))
        {
            inventorySystem.ClearInventory();
        }

        if(Input.GetKeyDown(KeyCode.F))
        {
            inventorySystem.ClearSelected();
        }

        if(Input.mouseScrollDelta.y == 1)
        {
            inventorySystem.DownSelected();
        }
        if(Input.mouseScrollDelta.y == -1)
        {
            inventorySystem.UpSelected();
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition
            (rb.position +
            (Speed * Time.fixedDeltaTime * direction.normalized));
    }
}