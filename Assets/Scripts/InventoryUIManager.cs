using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIManager : MonoBehaviour
{
    public PlayerManager player;

    [Space(10)]
    public GameObject invSlot;
    public GameObject uiItem;

    private bool active;

    private Vector2 visPos;
    private Vector2 invisPos;

    private Vector2 UiVisPos;
    private Vector2 UiInvisPos;

    public void UpdateUi()
    {
        ClearItems();
        string[] names = player.GetInventoryItemNames();

        for (int i = 0; i < names.Length; i++)
        {
            Pickup pi = GameManager.Instance.GetPickupWithName(names[i]);
            GameObject go = Instantiate(invSlot, transform);
            go.GetComponent<InventorySlot>().SetItemName(pi.itemName);

            if (pi.itemDiscription != null)
            {
                go.GetComponent<InventorySlot>().SetItemDiscription(pi.itemDiscription);
            }

            go.GetComponent<Image>().sprite = pi.itemSprite;
        }
    }

    private void ClearItems()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }

    private void Start()
    {
        visPos = transform.position;
        UiVisPos = uiItem.transform.position;
        invisPos = new Vector2(transform.position.x, transform.position.y - 1000);
        UiInvisPos = new Vector2(uiItem.transform.position.x, uiItem.transform.position.y - 1000);

        transform.position = invisPos;
        uiItem.transform.position = UiInvisPos;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            active = !active;

            //proberen de hotbar naar beneden te doen en de speler te unlocken als de hotbar leeg is
            if (active)
            {
                if (transform.childCount > 0)
                {
                    player.Lock(false);
                    transform.position = visPos;
                    uiItem.transform.position = UiVisPos;
                }
                else if (transform.childCount <= 0)
                {
                    player.UnLock();
                }
                
            }
            else if (!active)
            {
                player.UnLock();
                transform.position = invisPos;
                uiItem.transform.position = UiInvisPos;
            }
        }
    }

}
