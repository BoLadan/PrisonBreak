using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Inventory inventory;

    public float initialMaxWeight = 100;

    // Start is called before the first frame update
    void Start()
    {
        inventory = new Inventory(initialMaxWeight);
    }

    public bool AddItem(Item i)
    {
        return inventory.AddItem(i);
    }

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.CompareTag("Interactable"))
        {
            IInteractable i = coll.gameObject.GetComponent<IInteractable>();
            i.Action(this);
        }
    }
}
