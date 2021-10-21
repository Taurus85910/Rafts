using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SkinChanger : MonoBehaviour
{
    private List<Level> _levels;
    private GameObject _playerPrefab;
    private List<DwellerBody> _dwellers = new List<DwellerBody>();
    private List<StandartDweller> _standartDwellers = new List<StandartDweller>();
    private List<MiniDweller> _miniDwellers = new List<MiniDweller>();
    
    public void SetDwellers(List<Level> levels, GameObject player)
    {
        _levels = levels;
        _playerPrefab = player;
        _levels.ForEach(level => level.gameObject.SetActive(true));
        _playerPrefab.SetActive(true);
        _dwellers = SetDwellers<DwellerBody>();
        _standartDwellers = SetDwellers<StandartDweller>();
        _miniDwellers = SetDwellers<MiniDweller>();
        _levels.ForEach(level => level.gameObject.SetActive(false));
        _playerPrefab.SetActive(false);
    }

    private List<T> SetDwellers<T>()
    {
        List<T> dwellers = new List<T>();
        foreach (var level in _levels)
        {
          dwellers = dwellers.Union(level.gameObject.GetComponentsInChildren<T>()).ToList();
        }
        dwellers = dwellers.Union(_playerPrefab.GetComponentsInChildren<T>()).ToList();
        return dwellers;
    }

    public void SetDwellersSkin()
    {
        foreach (DwellerBody dweller in _dwellers)
        {
                dweller.gameObject.SetActive(false);
        }
        if (SaveData.CurrentUnitSkin == 0)
        {
            foreach (StandartDweller standartDweller in _standartDwellers)
            {
                standartDweller.gameObject.SetActive(true);
            }
        }
        if (SaveData.CurrentUnitSkin == 1)
        {
            foreach (MiniDweller miniDweller in _miniDwellers)
            {
                miniDweller.gameObject.SetActive(true);
            }
        }
    }
}
