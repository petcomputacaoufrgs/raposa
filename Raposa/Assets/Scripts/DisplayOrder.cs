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
        display.transform.parent = this.gameObject.transform;
        display.transform.position = this.gameObject.transform.position;

        displayRenderer = display.AddComponent<SpriteRenderer>();
        displayRenderer.sprite = scriptPickUpable.Needed;
        displayRenderer.sortingOrder = 4;
        display.transform.localScale = new Vector2(0.65f, 0.65f);

        Vector2 displayPosition = display.transform.position;
        displayPosition.x += 0.2f * (RigthOrLeft ? 1 : -1);
        displayPosition.y += 0.18f;
        display.transform.position = displayPosition;

        backGroundOrder = Instantiate(display, this.transform);
        backGroundOrderRenderer = backGroundOrder.GetComponent<SpriteRenderer>();
        backGroundOrderRenderer.sprite = this.transform.parent.GetChild(0).GetComponent<SpriteRenderer>().sprite;
        backGroundOrderRenderer.sortingOrder = 3;
        backGroundOrder.transform.localScale = new Vector2(0.20f, 0.20f);
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
        Vector3 distanceObject = transform.position - player.transform.position; //Calculates the distance between player and object

        if (distanceObject.magnitude > Range) //If the player is out of range
        {
            return false; //The item cannot be picked up
        }

        return true; //If it passed all other checks, the item can be picked up
    }
}
