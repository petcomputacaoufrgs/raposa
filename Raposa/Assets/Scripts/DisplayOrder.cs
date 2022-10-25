using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayOrder : MonoBehaviour
{
    public float Range = 1f;
    public Vector3 Offset = new Vector3(0.28f, 0.2f, 0f);
    public int OrderInLayer = 4;
    private GameObject player;
    private GameObject display;
    private GameObject backGroundOrder;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        
        display = Instantiate(Resources.Load<GameObject>("Cafeteria/EmptyPrefab"), transform);
        backGroundOrder = Instantiate(Resources.Load<GameObject>("Cafeteria/Background"), transform);

        display.transform.position += Offset;
        backGroundOrder.transform.position += Offset;

        SpriteRenderer displayRenderer = display.AddComponent<SpriteRenderer>();
        displayRenderer.sprite = GetComponent<PickUpable>().Needed;
        displayRenderer.sortingOrder = OrderInLayer;
    }

    void Update()
    {
        if (CheckIfInRange())
        {
            display.SetActive(true);
            backGroundOrder.SetActive(true);
        }
        else
        {
            display.SetActive(false);
            backGroundOrder.SetActive(false);
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