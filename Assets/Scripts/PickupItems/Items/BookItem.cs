using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookItem : Item
{
    private string discription;

    public BookItem(string name, float weight, string discription) : base(name, weight)
    {
        this.discription = discription;
    }

    public string GetDiscription()
    {
        return discription;
    }
}
