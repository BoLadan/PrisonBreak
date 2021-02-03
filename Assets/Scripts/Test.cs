using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TestCreateItem();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TestCreateItem()
    {
        Item i = new AccessItem("Key of Doom", 10, 1);
        DebugItem(i);

        Item j = new BonusItem("Patato of the gods", 2, 100);
        DebugItem(j);
    }

    public void DebugItem(Item i)
    {
        string itemInfo = "The item's name is " + i.GetName() + " and weighs " + i.GetWeight() + " Kg";
        string extraInfo = "";

        if (i is AccessItem)
        {
            //casting
            AccessItem ai = (AccessItem) i;
            extraInfo = " and opens door: " + ai.GetDoorId();
        }
        else if (i is BonusItem)
        {
            //casting
            BonusItem bi = (BonusItem) i;
            extraInfo = " and gives you: " + bi.GetPoints();
        }

        print(itemInfo + extraInfo);
    }
}
