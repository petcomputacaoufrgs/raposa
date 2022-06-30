using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject Player;
    public Vector3 DistanceCamera;

    private void Start()
    {
        DistanceCamera = transform.position - Player.transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position = Player.transform.position + DistanceCamera;
    }
}
