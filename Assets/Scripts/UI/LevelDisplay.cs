using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDisplay : Display
{
    private void OnEnable()
    {
        _levelLoader.LevelChanged += OnValueChanged;
    }
    
    private void OnDisable()
    {
        _levelLoader.LevelChanged += OnValueChanged;
    }
}
