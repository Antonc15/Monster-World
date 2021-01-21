using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inspectable : MonoBehaviour
{
    public string[] texts;

    public void Clicked()
    {
        Debug.Log(texts[Random.Range(0, texts.Length)]);
    }
}
