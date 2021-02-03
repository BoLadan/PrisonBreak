using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Inventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        //TestCreateItem();
        TestInventoryFunctioanlity();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TestCreateItem()
    {
        print("========== Testing creation of items ==========");
        Item i = new AccessItem("Key of Doom", 10, 1);
        DebugItem(i);

        Item j = new BonusItem("Patato of the gods", 2, 100);
        DebugItem(j);
    }

    private void TestInventoryFunctioanlity()
    {
        print("========== Testing inventory functionalities ==========");
        Item i = new AccessItem("Key of Doom", 10, 1);
        Item j = new BonusItem("Patato of the gods", 50, 50);
        Item k = new BonusItem("Globe of eternal sunshine", 50, 100);

        if (inventory.AddItem(i))
        {
            print("Added " + i.GetName() + " to the inventory");
        }
        else
        {
            print("Failed to add " + i.GetName() + " to the inventory");
        }

        if (inventory.AddItem(j))
        {
            print("Added " + j.GetName() + " to the inventory");
        }
        else
        {
            print("Failed to add " + j.GetName() + " to the inventory");
        }

        if (inventory.AddItem(k))
        {
            print("Added " + k.GetName() + " to the inventory");
        }
        else
        {
            print("Failed to add " + k.GetName() + " to the inventory");
        }

        inventory.DebugInventory();

        if (inventory.CanOpenDoor(1))
        {
            print("Door 1 can be opened.");
        }
        else
        {
            print("Door 1 can NOT be opened");
        }

        if (inventory.CanOpenDoor(2))
        {
            print("Door 2 can be opened.");
        }
        else
        {
            print("Door 2 can NOT be opened");
        }
    }

    public void DebugItem(Item i)
    {
        string itemInfo = "The item's name is " + i.GetName() + " and weighs " + i.GetWeight() + " Kg";
        string extraInfo = "";

        if (i is AccessItem)
        {
            //casting
            //Transforming item 'i' in an AccessItem to access more variables
            AccessItem ai = (AccessItem) i;
            extraInfo = " and opens door: " + ai.GetDoorId();
        }
        else if (i is BonusItem)
        {
            //casting
            //Transforming item 'i' in an BonusItem to access more variables
            BonusItem bi = (BonusItem) i;
            extraInfo = " and gives you: " + bi.GetPoints();
        }

        print(itemInfo + extraInfo);
    }
}
