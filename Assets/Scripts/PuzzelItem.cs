using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzelItem : Item
{
    private string riddle;
    private string answer;

    private bool solved;

    public PuzzelItem(string name, float weight, string riddle, string answer) : base(name, weight)
    {
        this.riddle = riddle;
        this.answer = answer;
        this.solved = false;
    }

    public string GetRiddle()
    {
        return riddle;
    }

    public string GetAnswer()
    {
        return answer;
    }

    public bool GetSolved()
    {
        return solved;
    }

    public bool CheckForAnswer(string possibleAsnwer)
    {
        if (possibleAsnwer == answer)
        {
            solved = true;
        }
        else
        {
            solved = false;
        }
        return solved;
    }
}
