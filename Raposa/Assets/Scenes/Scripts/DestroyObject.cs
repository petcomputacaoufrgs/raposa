using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public float dist = 0.2f;    
    public GameObject Player;    
    Vector2 distanceObject; 

    // Update is called once per frame
    void Update()    
    {
        distanceObject = transform.position - Player.transform.position;
        if (distanceObject.magnitude <= dist)
        {            
            Debug.Log("Distance:" + distanceObject.magnitude);
            if(Input.GetButtonDown("Fire1"))
            {                
                Destroy(gameObject);
            }           
        }
    }
}
