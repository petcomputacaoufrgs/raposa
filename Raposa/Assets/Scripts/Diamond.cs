using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    private InGameUI inGameUI;

    private void Start()
    {
        inGameUI = FindObjectOfType(typeof(InGameUI)) as InGameUI;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(gameObject);
            inGameUI.ReloadDiamondsText();

            Debug.Log("Number of diamonds: " + inGameUI.NumDiamonds);
        }
    }
}
