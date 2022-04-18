using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDepth : MonoBehaviour
{
    public GameObject Player;
    private float delta;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        delta = Player.transform.position.y - transform.position.y;

        if (delta <= 0)
            spriteRenderer.sortingOrder = 1;
        else
            spriteRenderer.sortingOrder = 3;
    }
}
