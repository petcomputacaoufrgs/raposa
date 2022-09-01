using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDepth : MonoBehaviour
{
    private GameObject player;
    private float delta;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        delta = player.transform.position.y - transform.position.y;

        if (delta <= 0)
            spriteRenderer.sortingOrder = 1;
        else
            spriteRenderer.sortingOrder = 3;
    }
}
