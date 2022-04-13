using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float Speed = 1.5f;
    private Rigidbody rb;
    private Vector2 direction;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        direction = new Vector2(xAxis, yAxis);

    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().MovePosition
            (GetComponent<Rigidbody2D>().position +
            (direction * Speed * Time.deltaTime));
    }
}