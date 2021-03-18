using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveButton : MonoBehaviour
{
    public InventorySlot inventorySlot;


    public void RemoveItem()
    {
        PlayerManager.instance.DropItem(inventorySlot.GetItemName());
    }
}
