using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIManager : MonoBehaviour
{
    public PlayerManager player;

    [Space(10)]
    public GameObject invSlot;

    public void UpdateUi()
    {
        ClearItems();
        string[] names = player.GetInventoryItemNames();

        for (int i = 0; i < names.Length; i++)
        {
            Pickup pi = GameManager.Instance.GetPickupWithName(names[i]);
            GameObject go = Instantiate(invSlot, transform);
            go.GetComponent<InventorySlot>().SetItemName(pi.itemName);
            go.GetComponent<Image>().sprite = pi.itemSprite;
        }
    }

    private void ClearItems()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }

    
}
