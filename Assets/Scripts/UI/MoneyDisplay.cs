using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyDisplay : Display
{
    [SerializeField] private LevelLoader _levelLoader;

    private void OnEnable()
    {
        _levelLoader.LevelClosed += OnValueLoaded;
    }
    
    private void OnDisable()
    {
        _levelLoader.LevelClosed += OnValueLoaded;
    }
}
