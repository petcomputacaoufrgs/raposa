using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public float Dist = 0.2f;
    private GameObject player;
    public bool Consumable;
    private Vector2 distanceObject;

    // Update is called once per frame
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    void Update()
    {
        if (PlayerControl.Trigger)
        {
            distanceObject = transform.position - player.transform.position;
            if (distanceObject.magnitude <= Dist)
            {
                Debug.Log("Distance:" + distanceObject.magnitude);
                PointSystem.AddPoints(100);
                if(InventorySystem.AddItem(gameObject) && Consumable) Destroy(gameObject);
            }
        }
    }
}
