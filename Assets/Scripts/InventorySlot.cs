using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    public string itemName;

    public void SetItemName (string name)
    {
        itemName = name;
    }

    public string GetItemName()
    {
        return itemName;
    }

}
