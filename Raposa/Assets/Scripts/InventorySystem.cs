using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{
    public int Selected {get; private set;} = 0; //Which slot has been select
    public int NumberOfSlots = 4; //Number of slots you want
    public bool Vertical = true; //If the bar is vertical or horizontal
    public bool RightOrDown = true; //If the bar goes Right/Down or Left/Up
    public bool AutoCenter = true; //Controls if the cursor sprite will center on the hotbar or will keeps its offset
    private int _vertical;
    private int _direction;
    public List<GameObject> Slots {get; private set;} = new List<GameObject>(); //Inventory slots
    public GameObject InventoryLocation; //Location of the inventory on screen 
    private Image selectorSprite; //Image for the selector HUD
    private static Vector2 offset; //Space between each Inventory position
    private void Start()
    {
        //Variables initialization
        _vertical = System.Convert.ToInt16(Vertical);
        if(RightOrDown) _direction = -1; else _direction = 1;
        
        //Inventory UI initialization
        if(InventoryLocation == null) InventoryLocation = GameObject.FindWithTag("InventoryLocation");
        offset = InventoryLocation.GetComponent<SpriteRenderer>().transform.lossyScale;
        selectorSprite = InventoryLocation.GetComponentInChildren<Image>();
        if(AutoCenter) selectorSprite.transform.position = InventoryLocation.transform.position;
        UpdatePosition();
    }
    public bool AddItem(GameObject item)
    {
        if(NumberOfSlots > Slots.Count)
        {
            GameObject _item = Instantiate(item, InventoryLocation.transform); //Copy the object
            Debug.Log("Adding " + _item);
            _item.AddComponent<Image>(); //Adds the sprite thats going to appear in the hotbar
            _item.GetComponent<Image>().transform.position = PositionSetter(InventoryLocation, Slots.Count);
            _item.GetComponent<Image>().sprite = item.GetComponent<SpriteRenderer>().sprite;
            Slots.Add(_item); //Adds to the list
            UpdatePosition();
            return true;
        }
        return false;
    }
    public void ClearSelected()
    {   
        if(Selected > Slots.Count || Slots.Count == 0) return; //Error checking

        if(Slots[Selected] != null)
        {
            Destroy(Slots[Selected]); //Destroys the object
            Slots.RemoveAt(Selected); //Removes it from the list
            UpdatePosition(); //Updates the HUD positions
        }
    }
    public void ClearInventory()
    {
        foreach (var item in Slots)
        {
            Destroy(item); //Destroies everyitem
        }
        Slots.Clear(); //Clears the list
        Selected = 0;
        UpdatePosition();
    }
    /// <summary>Method for removing an Item from the inventory. CALL INSTEAD OF REMOVE AT, SAME SINTAX</summary>
    public void RemoveItem(int index)
    {
        Destroy(Slots[index]); //Destroys the object
        Slots.RemoveAt(index); //Removes it from the list
        UpdatePosition(); //Updates the HUD positions
    }
    public void UpSelected()
    {
        if(Slots.Count == 0)
        {
            Selected = 0; //Error checking //! Not divide by 0
            return;
        }

        Selected = Mathf.Abs((Selected+1)%Slots.Count); //Rolling HUD

        UpdatePosition();
    }
    public void DownSelected()
    {
        if(Slots.Count == 0)
        {
            Selected = 0; //Error checking //! Not divide by 0
            return;
        }

        if(Selected == 0)
        {
            Selected = Slots.Count-1; //Edge case
        }
        else
        {
            Selected = Mathf.Abs((Selected-1)%Slots.Count); //Rolling HUD
        }

        UpdatePosition();
    }
    public void UpdatePosition()
    {
        //List Changes
        foreach (var item in Slots)
        {
            item.GetComponent<Image>().transform.position = PositionSetter(Slots.IndexOf(item)); //Updates the position of everything on the list
        }
        
        //Cursor changes
        if(Slots.Count == 0) selectorSprite.enabled = false; else selectorSprite.enabled = true;
        while(Selected >= Slots.Count && Selected != 0) Selected--;
        selectorSprite.transform.position = PositionSetter(Selected); //Gets the right input position
    }
    private Vector3 PositionSetter(int op)
    {
        Vector3 blah = new Vector3 (
                selectorSprite.transform.position.x + _direction*(_vertical-1)*offset.x*op, //Adds the location of the anchor to the offset
                InventoryLocation.transform.position.y + _direction*_vertical*offset.y*op, //Adds the location of the anchor to the offset
                selectorSprite.transform.position.z
        );
        return blah; //Returns the right vector3
    }
    private Vector3 PositionSetter(GameObject _base, int op)
    {
        Vector3 blah = new Vector3 (
                _base.transform.position.x + _direction*(_vertical-1)*offset.x*op, //Adds the location of the anchor to the offset
                _base.transform.position.y + _direction*_vertical*offset.y*op, //Adds the location of the anchor to the offset
                _base.transform.position.z
        );
        return blah; //Returns the right vector3
    }
}
