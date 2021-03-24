using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public InventoryUIManager uiManager;

    private Dictionary<string, Pickup> worldItems = new Dictionary<string, Pickup>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RegisterPickupItem(Pickup i)
    {
        if (!worldItems.ContainsKey(i.itemName))
        {
            worldItems.Add(i.itemName, i);
        }
        else
        {
            Debug.LogError("There is allready an object with the name: " + i.itemName + " There can not be two items with the same name.");
        }
        
    }

    public void DropItem(string name, Vector3 position)
    {
        worldItems[name].Respawn(position);
    }

    public Pickup GetPickupWithName(string name)
    {
        Debug.Log("Getting: " + name);
        return worldItems[name];
    }

    public void TriggerUIUpdate()
    {
        uiManager.UpdateUi();
    }
}
