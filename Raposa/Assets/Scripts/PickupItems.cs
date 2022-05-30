using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItems : MonoBehaviour
{
    public float dist = 0.2f;
    public GameObject Player;
    Vector2 distanceObject;
    private InGameUI inGameUI;

    private void Start()
    {
        inGameUI = FindObjectOfType(typeof(InGameUI)) as InGameUI;
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.GameIsPaused)
        {
            distanceObject = transform.position - Player.transform.position;
            if (distanceObject.magnitude <= dist)
            {
                Debug.Log("Distance:" + distanceObject.magnitude);
                if (Input.GetButtonDown("Fire1")||Input.GetKeyDown(KeyCode.Space))
                {
                    Destroy(gameObject);

                    inGameUI.ReloadDiamondsText();
                    
                    inGameUI.EndGame();

                    Debug.Log("Number of diamonds: " + inGameUI.NumDiamonds);
                }
            }
        }
    }
}
