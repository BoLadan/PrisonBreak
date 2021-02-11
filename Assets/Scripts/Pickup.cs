﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickup : MonoBehaviour, IInteractable
{
    public string itemName;
    public float weight;

    [Space(10)]
    public Sprite itemSprite;

    void Start()
    {
        gameObject.tag = "Interactable";
        GameManager.Instance.RegisterPickupItem(this);
    }

    public void Action(PlayerManager player)
    {
        // is there is enough space in the inventory you can pick up the item and it'll disapear
        if (player.AddItem(CreateItem()))
        {
            Remove();
        }
    }

    public void Remove()
    {
        gameObject.SetActive(false);
    }

    public void Respawn(Vector3 position)
    {
        gameObject.transform.position = new Vector3(position.x, position.y, position.z);
        gameObject.SetActive(true);
    }

    public abstract Item CreateItem();
}
