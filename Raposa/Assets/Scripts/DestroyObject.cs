using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public float Dist = 0.2f;
    private GameObject player;
    public bool Consumable;
    private Vector2 distanceObject;
    private PlayerControl playerControl;
    private PointSystem pointSystem;
    private InventorySystem inventorySystem;

    // Update is called once per frame
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerControl = player.GetComponent<PlayerControl>();
        pointSystem = player.GetComponent<PointSystem>();
        inventorySystem = player.GetComponent<InventorySystem>();
    }
    void Update()
    {
        if (playerControl.Trigger)
        {
            distanceObject = transform.position - player.transform.position;
            if (distanceObject.magnitude <= Dist)
            {
                Debug.Log("Distance:" + distanceObject.magnitude);
                pointSystem.AddPoints(100);
                if(inventorySystem.AddItem(gameObject) && Consumable) Destroy(gameObject);
            }
        }
    }
}
