using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance { get; private set; }

    private Inventory inventory;

    public float initialMaxWeight = 100;
    public float maxDistanceRaycast;

    [Space(10)]
    public GameObject fKey;
    [SerializeField]
    private GameObject inputfield;

    [Space(10)]
    public List<GameObject> objectsToLock = new List<GameObject>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        inventory = new Inventory(initialMaxWeight);
    }

    private void Update()
    {

        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.TransformDirection(Vector3.forward), out hit, maxDistanceRaycast))
        {
            Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            //Debug.Log("Did Hit");

            if (hit.collider.gameObject.CompareTag("Interactable"))
            {
                fKey.SetActive(true);
                if (Input.GetKeyDown(KeyCode.F))
                {
                    IInteractable i = hit.collider.gameObject.GetComponent<IInteractable>();
                    i.Action(this);
                }
            }
            else
            {
                fKey.SetActive(false);
            }
        }
        else
        {
            Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.TransformDirection(Vector3.forward) * maxDistanceRaycast, Color.red);
            //Debug.Log("Did not Hit");

            fKey.SetActive(false);
        }

    }

    public void DropItem(string name)
    {
        Item i = inventory.GetItemWithName(name);

        if (i != null)
        {
            inventory.RemoveItem(i);
            Vector3 dropPos = new Vector3(transform.position.x, transform.position.y + 0.7f, transform.position.z);
            GameManager.Instance.DropItem(name, dropPos + transform.forward);
            GameManager.Instance.TriggerUIUpdate();
        }
    }

    public bool AddItem(Item i)
    {
        bool success = inventory.AddItem(i);

        if (success)
        {
            GameManager.Instance.TriggerUIUpdate();
        }

        return success;
    }

    public string[] GetInventoryItemNames()
    {
        return inventory.GetInventoryItemNames();
    }

    public bool CanOpenDoor(int id)
    {
        return inventory.CanOpenDoor(id);
    }

    public void Lock(bool showInputField)
    {
        for (int i = 0; i < objectsToLock.Count; i++)
        {
            objectsToLock[i].GetComponent<MonoBehaviour>().enabled = false;
        }
        if (showInputField)
        {
            ShowInputField(true);
        }  
    }

    public void UnLock()
    {
        for (int i = 0; i < objectsToLock.Count; i++)
        {
            objectsToLock[i].GetComponent<MonoBehaviour>().enabled = true;
        }
        ShowInputField(false);
    }

    private void ShowInputField(bool state)
    {
        inputfield.SetActive(state);
    }
}
