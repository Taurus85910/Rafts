using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDisplay : Display
{
    [SerializeField] private LevelLoader _levelLoader;

    private void OnEnable()
    {
        _levelLoader.LevelLoaded += OnValueLoaded;
    }
    
    private void OnDisable()
    {
        _levelLoader.LevelLoaded += OnValueLoaded;
    }
}
