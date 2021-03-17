using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public int doorId;

    public bool open;

    private void Start()
    {
        gameObject.tag = "Interactable";
    }
    public void Open()
    {
        open = !open;
    }
    public void Action(PlayerManager player)
    {
        if (player.CanOpenDoor(doorId))
        {
            Debug.Log("Door opens");
            Open();
        }
    }
}
