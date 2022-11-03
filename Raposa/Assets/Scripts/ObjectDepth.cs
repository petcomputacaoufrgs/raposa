using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDepth : MonoBehaviour
{
    public int DepthLayer = 0;
    private int originalLayer;
    private GameObject player;
    private float delta;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalLayer = spriteRenderer.sortingOrder;
    }

    private void Update()
    {
        delta = player.transform.position.y - transform.position.y;

        if (delta <= 0)
            spriteRenderer.sortingOrder = originalLayer;
        else
            spriteRenderer.sortingOrder = DepthLayer;
    }
}
