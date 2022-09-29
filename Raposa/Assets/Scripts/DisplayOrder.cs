using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayOrder : MonoBehaviour
{
    private GameObject player;
    private PickUpable scriptPickUpable;
    private GameObject display;
    private SpriteRenderer displayRenderer;
    private GameObject backGroundOrder;
    private SpriteRenderer backGroundOrderRenderer;
    public bool RigthOrLeft = true;
    public float Range = 0.5f;

    void Start()
    {
        scriptPickUpable = GetComponent<PickUpable>();
        player = GameObject.FindWithTag("Player");

        display = new GameObject("display");
        Vector2 displayPosition = display.transform.position;

        display.transform.parent = transform;
        displayPosition = transform.position;
        display.transform.localScale = new Vector2(0.65f, 0.65f);
        displayPosition.x += 0.2f * (RigthOrLeft ? 1 : -1);
        displayPosition.y += 0.18f;
        display.transform.position = displayPosition;

        displayRenderer = display.AddComponent<SpriteRenderer>();
        displayRenderer.sprite = scriptPickUpable.Needed;
        displayRenderer.sortingOrder = 4;
        
        backGroundOrder = Instantiate(display, transform);
        backGroundOrder.transform.localScale = new Vector2(0.20f, 0.20f);

        backGroundOrderRenderer = backGroundOrder.GetComponent<SpriteRenderer>();
        backGroundOrderRenderer.sprite = transform.parent.GetChild(0).GetComponent<SpriteRenderer>().sprite;
        backGroundOrderRenderer.sortingOrder = 3;
    }

    void Update()
    {
        if (CheckIfInRange())
        {
            displayRenderer.enabled = true;
            backGroundOrderRenderer.enabled = true;
        }
        else
        {
            displayRenderer.enabled = false;
            backGroundOrderRenderer.enabled = false;
        }
    }

    private bool CheckIfInRange()
    {
        Vector3 distanceObject = transform.position - player.transform.position;

        if (distanceObject.magnitude > Range)
        {
            return false;
        }

        return true;
    }
}