using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpable : MonoBehaviour
{
    public float Dist = 0.2f; //Player distance to pickup item
    public bool Consumable; //Determines if the item will vanish after picking it up
    public Sprite Needed; //If 'null' the item doesn't have prerequisits, else, determines the prerequisit
    private bool client; //Determines if the object this script is attached is a Client
    private GameObject player; //Variable assigned to the player GameObject
    private Vector2 distanceObject; //Distance between the object and the player
    private PlayerControl playerControl; //Variable that points to the PlayerControl System, for getting the trigger
    private InventorySystem inventorySystem; //Variable for manipulating the inventory

    void Start()
    {
        client = gameObject.CompareTag("Client"); //Determines if the object is a client by it's tag
        //Makes all the variables point to the right place
        player = GameObject.FindWithTag("Player");
        playerControl = player.GetComponent<PlayerControl>();
        inventorySystem = player.GetComponent<InventorySystem>();
    }
    void Update()
    {
        if (!CheckIfInRange() || !CheckSelectedItem()) //Tests if the player is in range or if the item selected is correct
        {
            return; //If not, terminates the function
        }

        if (client) //If it's a client
        {
            inventorySystem.RemoveItemAt(inventorySystem.Selected); //Removes the item from the inventory
            Destroy(gameObject); //Destroys the client
            return; //Terminates the function
        }

        //All primary checks passed, Need to determine what to do with the item
        if (Needed == null) //If the item doesn't have prerequisits
        {
            if (inventorySystem.AddItem(gameObject)) //Adds the new item to the inventory
            {
                if (Consumable) //If it's consumable
                {
                    Destroy(gameObject); //Destroies the Object
                }
            }
        }
        else //If it does have prerequisits
        {
            if (inventorySystem.SwapItemAt(inventorySystem.Selected, gameObject)) //Swaps the current item to the new item on the inventory
            {
                if (Consumable) //If it's consumable
                {
                    Destroy(gameObject); //Destroies the Object
                }
            }
        }
    }
    private bool CheckSelectedItem()
    {
        if (Needed == null) //If it doesn't have prerequisits
        {
            return true; //We don't need to check if the item is correct
        }

        int selection = inventorySystem.Selected; //Assings the variable from the inventory for easy reading

        if (inventorySystem.Slots.Count == 0) //If the inventory is empty
        {
            return false; //Returns false, prevents acessing an index out of range
        }

        if (inventorySystem.Slots[selection].GetComponent<Image>().sprite == Needed) //If the sprite is the same as the prerequisits 
        {
            return true;
        }

        return false; //If all previous checks failed, it means the item held is wrong
    }
    private bool CheckIfInRange()
    {
        if (!playerControl.Trigger) //Checks if the player trigger is active
        {
            return false; //If not, ends the function
        }

        distanceObject = transform.position - player.transform.position; //Calculates the distance between player and object

        if (distanceObject.magnitude > Dist) //If the player is out of range
        {
            return false; //The item cannot be picked up
        }

        return true; //If it passed all other checks, the item can be picked up
    }
}
