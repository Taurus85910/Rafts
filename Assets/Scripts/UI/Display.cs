using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public abstract class Display : MonoBehaviour
{
    private Text _text;

    private void Start()
    {
        _text = GetComponent<Text>();
    }

    protected void OnValueLoaded(int value)
    {
        _text.text = value.ToString();
    }
}
