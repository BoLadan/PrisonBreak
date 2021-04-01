using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventorySlot : MonoBehaviour
{
    private string itemName;
    private string itemDiscription;

    public Text discriptionText;

    private void Start()
    {
        discriptionText = GameObject.FindGameObjectWithTag("ItemDiscription").GetComponent<Text>();
    }


    public void SetItemName (string name)
    {
        itemName = name;
    }

    public string GetItemName()
    {
        return itemName;
    }

    public string SetItemDiscription(string discription)
    {
        itemDiscription = discription;
        return itemDiscription;
    }

    public void GetItemDiscription()
    {
        if (itemDiscription != null)
        {
            discriptionText.text = itemDiscription;
        }
        else
        {
            discriptionText.text += " No Discription";
        }
    }
}
