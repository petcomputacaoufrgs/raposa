using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpable : MonoBehaviour
{
    public float Dist = 0.2f;
    public bool Consumable;
    public bool Client;
    public Sprite Needed;
    public int PointsGained;
    public int PointsLost;
    private GameObject player;
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
        if (!CheckIfInRange())
        {
            return;
        }

        if (!CheckSelectedItem())
        {
            pointSystem.RemovePoints(PointsLost);
            return;
        }

        pointSystem.AddPoints(PointsGained);

        if (Client)
        {
            inventorySystem.RemoveItemAt(inventorySystem.Selected);
            Destroy(gameObject);
            return;
        }


        if (Needed == null)
        {
            if (inventorySystem.AddItem(gameObject))
            {
                if (Consumable)
                {
                    Destroy(gameObject);
                }
            }
        }
        else
        {
            if (inventorySystem.SwapItemAt(inventorySystem.Selected, gameObject))
            {
                if (Consumable)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
    private bool CheckSelectedItem()
    {
        if (Needed == null)
        {
            return true;
        }

        int selection = inventorySystem.Selected;

        if (inventorySystem.Slots.Count == 0)
        {
            return false;
        }

        if (inventorySystem.Slots[selection].GetComponent<Image>().sprite == Needed)
        {
            return true;
        }

        return false;
    }
    private bool CheckIfInRange()
    {
        if (!playerControl.Trigger)
        {
            return false;
        }

        distanceObject = transform.position - player.transform.position;

        if (distanceObject.magnitude > Dist)
        {
            return false;
        }

        return true;
    }
}
