using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReciveInput : MonoBehaviour
{
    private string input;

    [SerializeField]
    private Text computerText;

    public void GetInput(string input)
    {
        this.input = input;
        Debug.Log(this.input);
    }

    public void CheckForCorrectInput()
    {
        if (input == APIConnection.instance.GetAuthKey())
        {
            Debug.Log("Access Granted!");
            computerText.text = "Access Granted";
        }
        else
        {
            Debug.Log("Access Denied!");
            computerText.text = "Access Denied";
        }
    }
}
