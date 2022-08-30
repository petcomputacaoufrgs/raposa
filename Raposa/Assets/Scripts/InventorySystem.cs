using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{
    public static int Selected {get; private set;}
    public int NumberOfSlots = 4;
    public bool Vertical = true;
    public bool RightOrDown = true;
    private static int _numberOfSlots;
    private static int _vertical;
    private static int _direction;
    public static List<GameObject> slots;
    private static GameObject inventoryLocation;
    public Image Selector;
    private static Image _selector;
    private static Vector2 offset;

    private void Start()
    {
        _numberOfSlots = NumberOfSlots;
        _vertical = System.Convert.ToInt16(Vertical);
        if(RightOrDown) _direction = -1; else _direction = 1;
        _selector = Selector;

        Selected = 0;
        slots = new List<GameObject>();
        inventoryLocation = GameObject.FindWithTag("InventoryLocation");
        
        offset.y = inventoryLocation.GetComponent<SpriteRenderer>().transform.lossyScale.y;
        offset.x = inventoryLocation.GetComponent<SpriteRenderer>().transform.lossyScale.x;
        
        _selector.transform.position = inventoryLocation.transform.position;
        
    }
    public static bool AddItem(GameObject item)
    {
        if(slots.Count < _numberOfSlots)
        {
            GameObject _item = Instantiate(item, inventoryLocation.transform);
            Debug.Log("Adding " + _item);
            _item.AddComponent<Image>();
            _item.GetComponent<Image>().transform.position = PositionSetter(slots.Count);
            _item.GetComponent<Image>().sprite = item.GetComponent<SpriteRenderer>().sprite;
            slots.Add(_item);
            return true;
        }
        return false;
    }
    public static void ClearSelected()
    {   
        if(Selected > slots.Count || slots.Count == 0) return;

        if(slots[Selected] != null)
        {
            Destroy(slots[Selected]);
            slots.RemoveAt(Selected);
            UpdatePosition();
        }
    }
    public static void ClearInventory()
    {
        foreach (var item in slots)
        {
            Destroy(item);
        }
        slots.Clear();
    }
    public static void UpSelected()
    {
        if(slots.Count == 0)
        {
            Selected = 0;
            return;
        }

        Selected = Mathf.Abs((Selected+1)%slots.Count);

        _selector.transform.position = PositionSetter(Selected);
    }
    public static void DownSelected()
    {
        if(slots.Count == 0)
        {
            Selected = 0;
            return;
        }

        if(Selected == 0)
        {
            Selected = slots.Count-1;
        }
        else
        {
            Selected = Mathf.Abs((Selected-1)%slots.Count);
        }

        _selector.transform.position = PositionSetter(Selected);
    }
    public static void UpdatePosition()
    {
        foreach (var item in slots)
        {
            item.GetComponent<Image>().transform.position = PositionSetter(slots.IndexOf(item));
        }
    }
    private static Vector3 PositionSetter(int op)
    {
        Vector3 blah = new Vector3 (
                inventoryLocation.transform.position.x + _direction*(_vertical-1)*offset.x*op,
                inventoryLocation.transform.position.y + _direction*_vertical*offset.y*op,
                inventoryLocation.transform.position.z
        );
        return blah;
    }
}
