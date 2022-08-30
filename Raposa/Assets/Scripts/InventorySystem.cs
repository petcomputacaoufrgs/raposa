using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{
    public static int Selected {get; private set;} = 0; //Which slot has been select
    public int NumberOfSlots = 4; //Number of slots you want
    public bool Vertical = true; //If the bar is vertical or horizontal
    public bool RightOrDown = true; //If the bar goes Right/Down or Left/Up
    private static int _numberOfSlots;
    private static int _vertical;
    private static int _direction;
    public static List<GameObject> slots; //Inventory slots
    private static GameObject inventoryLocation; //Location of the inventory on screen 
    public Image Selector; //Image for the selector HUD
    private static Image _selector;
    private static Vector2 offset; //Space between each Inventory position

    private void Start()
    {
        //Variables initialization
        _numberOfSlots = NumberOfSlots;
        _vertical = System.Convert.ToInt16(Vertical);
        if(RightOrDown) _direction = -1; else _direction = 1;
        _selector = Selector;

        slots = new List<GameObject>(); //List initialization
        
        //Inventory UI initialization
        inventoryLocation = GameObject.FindWithTag("InventoryLocation");
        offset = inventoryLocation.GetComponent<SpriteRenderer>().transform.lossyScale;
        _selector.transform.position = inventoryLocation.transform.position;
    }
    public static bool AddItem(GameObject item)
    {
        if(_numberOfSlots > slots.Count)
        {
            GameObject _item = Instantiate(item, inventoryLocation.transform); //Copy the object
            Debug.Log("Adding " + _item);
            _item.AddComponent<Image>(); //Adds the sprite thats going to appear in the hotbar
            _item.GetComponent<Image>().transform.position = PositionSetter(slots.Count);
            _item.GetComponent<Image>().sprite = item.GetComponent<SpriteRenderer>().sprite;
            slots.Add(_item); //Adds to the list
            return true;
        }
        return false;
    }
    public static void ClearSelected()
    {   
        if(Selected > slots.Count || slots.Count == 0) return; //Error checking

        if(slots[Selected] != null)
        {
            Destroy(slots[Selected]); //Destroys the object
            slots.RemoveAt(Selected); //Removes it from the list
            UpdatePosition(); //Updates the HUD positions
        }
    }
    public static void ClearInventory()
    {
        foreach (var item in slots)
        {
            Destroy(item); //Destroies everyitem
        }
        slots.Clear(); //Clears the list
    }
    public static void UpSelected()
    {
        if(slots.Count == 0)
        {
            Selected = 0; //Error checking //! Not divide by 0
            return;
        }

        Selected = Mathf.Abs((Selected+1)%slots.Count); //Rolling HUD

        _selector.transform.position = PositionSetter(Selected); //Gets the right input position
    }
    public static void DownSelected()
    {
        if(slots.Count == 0)
        {
            Selected = 0; //Error checking //! Not divide by 0
            return;
        }

        if(Selected == 0)
        {
            Selected = slots.Count-1; //Edge case
        }
        else
        {
            Selected = Mathf.Abs((Selected-1)%slots.Count); //Rolling HUD
        }

        _selector.transform.position = PositionSetter(Selected); //Gets the right input position
    }
    public static void UpdatePosition()
    {
        foreach (var item in slots)
        {
            item.GetComponent<Image>().transform.position = PositionSetter(slots.IndexOf(item)); //Updates the position of everything on the list
        }
    }
    private static Vector3 PositionSetter(int op)
    {
        Vector3 blah = new Vector3 (
                inventoryLocation.transform.position.x + _direction*(_vertical-1)*offset.x*op, //Adds the location of the anchor to the offset
                inventoryLocation.transform.position.y + _direction*_vertical*offset.y*op, //Adds the location of the anchor to the offset
                inventoryLocation.transform.position.z
        );
        return blah; //Returns the right vector3
    }
}
