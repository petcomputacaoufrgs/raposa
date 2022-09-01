using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private GameObject player;
    private Vector3 distanceCamera;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        distanceCamera = transform.position - player.transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position = player.transform.position + distanceCamera;
    }
}
