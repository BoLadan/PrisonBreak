using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<Item> items = new List<Item>();
    private float weight;
    public float maximumWeight = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool AddItem(Item i)
    {
        // first check if current weight + the one that i'm adding (totalweight) is smaller then maximumWeight
        // add item to list and cash new weight
        if (weight + i.GetWeight() <= maximumWeight)
        {
            items.Add(i);
            weight += i.GetWeight();
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
        print("Inventory has: " + Count() + " Items");
        print("Total weight: " + GetCurrentWeight());

        foreach (Item item in items)
        {
            print(item.GetName()+ "-------" + item.GetWeight() + "Kg");
        }
    }
}
