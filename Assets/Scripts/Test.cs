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
        Item i = new Item("Key of Doom", 10);
        print("The item's name is " + i.GetName() + " and weighs " + i.GetWeight() + " Kg.");
    }
}
