using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : Pickup
{
    public string discription;

    public override Item CreateItem()
    {
        return new BookItem(name, weight, discription);
    }
}
