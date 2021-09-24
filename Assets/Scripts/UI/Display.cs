using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public abstract class Display : MonoBehaviour
{ 
    [SerializeField] protected LevelLoader _levelLoader;
    
    private Text _text;

    private void Awake()
    {
        _text = GetComponent<Text>();
    }

    protected void OnValueChanged(int value)
    {
        _text.text = value.ToString();
    }
}
