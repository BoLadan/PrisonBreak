using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoor : MonoBehaviour
{
    private Vector3 dest;

    [HideInInspector]
    public bool open;

    // Start is called before the first frame update
    void Start()
    {
        dest = new Vector3(transform.position.x ,transform.position.y - 10, transform.position.z);
    }

    private void Update()
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
}
