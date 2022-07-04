using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public float Dist = 0.2f;
    public GameObject Player;
    public Vector2 DistanceObject;

    // Update is called once per frame
    void Update()
    {
        if (Player.GetComponent<PlayerControl>().Trigger)
        {
            DistanceObject = transform.position - Player.transform.position;
            if (DistanceObject.magnitude <= Dist)
            {
                Debug.Log("Distance:" + DistanceObject.magnitude);
                
                Destroy(gameObject);
            }
        }
    }
}
