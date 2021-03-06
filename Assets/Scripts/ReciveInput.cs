using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReciveInput : MonoBehaviour
{
    private string input;
    private string correctInput;
    private string defaultText;
    private string accessGrantedText;
    private string accessDeniedText;

    [SerializeField]
    private Text computerText;

    [Space(10)]
    public FinalDoor finalDoor;

    private void Start()
    {
        correctInput = APIConnection.instance.GetAuthKey();
        defaultText = computerText.text;
        accessGrantedText = "Access Granted";
        accessDeniedText = "Access Denied";
    }

    public void GetInput(string input)
    {
        this.input = input;
        Debug.Log(this.input);
    }

    public void CheckForCorrectInput()
    {
        if (input == correctInput)
        {
            //Access granted
            StartCoroutine(ChangeText(accessGrantedText));
            finalDoor.open = true;
        }
        else
        {
            //Access denied
            StartCoroutine(ChangeText(accessDeniedText));
        }
    }

    IEnumerator ChangeText(string text)
    {
        computerText.text = text;
        yield return new WaitForSeconds(3);
        computerText.text = defaultText;

        yield return null;
    }
}
