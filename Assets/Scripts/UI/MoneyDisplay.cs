using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyDisplay : Display
{
    private void OnEnable()
    {
        _levelLoader.MoneyChanged += OnValueChanged;
    }
    
    private void OnDisable()
    {
        _levelLoader.MoneyChanged += OnValueChanged;
    }
}
