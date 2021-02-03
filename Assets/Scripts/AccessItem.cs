using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessItem : Item
{
    private int doorId;
    public AccessItem(string name, float weight, int doorId) : base(name, weight)
    {
        this.doorId = doorId;
    }

    public int GetDoorId()
    {
        return doorId;
    }
}
