using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private List<Item> items;
    private float weight;
    private float maximumWeight;

    public Inventory()
    {
        items = new List<Item>();
        weight = 0;
        maximumWeight = 100;
    }

    //door ': this()' word eerst de eerste constructor uitgevoerd en daarna kan de flaot maximumWeight aangepast worden aangezien je dei als enige wilt aanpassen in deeze situatie.
    // 'this()' word dus als basis gebruikt
    public Inventory(float maximumWeight) : this()
    {
        this.maximumWeight = maximumWeight;
    }

    public bool SetMaximumWeight(float maxWeight)
    {
        if (maxWeight >= weight)
        {
            maximumWeight = maxWeight;
            return true;
        }
        return false;
    }

    public bool AddItem(Item i)
    {
        // first check if current weight + the one that i'm adding (totalweight) is smaller then maximumWeight
        // add item to list and cash new weight
        if (weight + i.GetWeight() <= maximumWeight)
        {
            items.Add(i);
            weight += i.GetWeight();
            GetInventoryItemNames();
            return true;
        }
        else
        {
            return false;
        }

    }

    public bool RemoveItem(Item i)
    {
        bool succes = items.Remove(i);

        // if succesfull to remove item form list
        if (succes)
        {
            weight -= i.GetWeight();
        }
        return succes;

    }

    public Item GetItemWithName(string name)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].GetName() == name)
            {
                return items[i];
            }
        }
        return null;
    }

    public string[] GetInventoryItemNames()
    {
        string[] names = new string[items.Count];

        for (int i = 0; i < names.Length; i++)
        {
            names[i] = items[i].GetName();
        }
        return names;
    }

    public bool HasItem(Item i)
    {
        return items.Contains(i);
    }

    public bool CanOpenDoor(int id)
    {
        bool result = false;

        foreach (Item item in items)
        {
            if (item is AccessItem)
            {
                if (((AccessItem) item).OpensDoor(id))
                {
                    result = true;
                }
            }
        }

        return result;
    }

    public int Count()
    {
        return items.Count;
    }

    public float GetCurrentWeight()
    {
        return weight;
    }

    public void DebugInventory()
    {
        Debug.Log("Inventory has: " + Count() + " Items");
        Debug.Log("Total weight: " + GetCurrentWeight());

        foreach (Item item in items)
        {
            Debug.Log(item.GetName()+ "-------" + item.GetWeight() + "Kg");
        }
    }
}
