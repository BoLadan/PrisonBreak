using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataExercisee : MonoBehaviour
{
    List<string> words;

    // Start is called before the first frame update
    void Start()
    {
        words = new List<string>();
        Debug.Log(words.Capacity);

        words.Add("David");
        words.Add("is");
        words.Add("super");
        words.Add("hyper");
        words.Add("cool");

        Debug.Log(words[0]); // output David
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
