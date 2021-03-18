using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour, IInteractable
{
    private void Start()
    {
        gameObject.tag = "Interactable";
    }


    public void Action(PlayerManager player)
    {
        player.Lock(true);
    }
}
