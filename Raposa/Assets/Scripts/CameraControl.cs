using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject Player;
    Vector3 distanceCamera;

    private void Start()
    {
        distanceCamera = transform.position - Player.transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position = Player.transform.position + distanceCamera;
    }
}
