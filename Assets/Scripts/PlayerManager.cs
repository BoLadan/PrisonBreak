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

    private void Update()
    {
        //dropping item
        if (Input.GetKeyDown(KeyCode.F))
        {
            DropItem("Key of Doom");
        }
    }

    public void DropItem(string name)
    {
        Item i = inventory.GetItemWithName(name);

        if (i != null)
        {
            inventory.RemoveItem(i);
            GameManager.Instance.DropItem(name, transform.position + transform.forward);
        }
    }

    public bool AddItem(Item i)
    {
        return inventory.AddItem(i);
    }

    public bool CanOpenDoor(int id)
    {
        return inventory.CanOpenDoor(id);
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
