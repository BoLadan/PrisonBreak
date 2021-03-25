using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public int doorId;

    public bool open;

    private Vector3 dest;

    private void Start()
    {
        gameObject.tag = "Interactable";
        dest = new Vector3(transform.position.x, transform.position.y - 10, transform.position.z);
    }

    void Update()
    {
        if (open)
        {
            Open();
        }
    }

    public void Open()
    {
        if (transform.position != dest)
        {
            transform.position = Vector3.Lerp(transform.position, dest, 0.001f);
        }
    }

    public void Action(PlayerManager player)
    {
        if (player.CanOpenDoor(doorId))
        {
            Debug.Log("Door opens");
            open = true;
        }
    }
}
