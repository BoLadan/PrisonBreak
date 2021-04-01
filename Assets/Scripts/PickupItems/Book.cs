using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : Pickup
{
    public string discription;

    public override Item CreateItem()
    {
        itemDiscription = discription;
        return new BookItem(itemName, weight, discription);
    }
}
