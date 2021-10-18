using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TMP_Text))]
public abstract class Display : MonoBehaviour
{ 
    [SerializeField] protected LevelLoader _levelLoader;
    
    private TMP_Text _text;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }

    protected void OnValueChanged(int value)
    {
        _text.text = value.ToString();
    }
}
