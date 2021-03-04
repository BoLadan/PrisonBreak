using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReciveInput : MonoBehaviour
{
    private string input;

    public void GetInput(string input)
    {
        this.input = input;
        Debug.Log(this.input);
    }
}
