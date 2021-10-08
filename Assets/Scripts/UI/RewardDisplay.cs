using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardDisplay : Display
{
    private void OnEnable()
    {
        _levelLoader.RewardChanged += OnValueChanged;
    }
    
    private void OnDisable()
    {
        _levelLoader.RewardChanged += OnValueChanged;
    }
}
