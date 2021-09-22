using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveCore : MonoBehaviour
{
    [SerializeField] private Text _text;
    
    private Saver _saver;
    private SaveData _saveData;
    
    private void Start()
    {
        _saveData = new SaveData();
        _saver = new Saver();
        OnLoadBtnClicked();
    }

    public void AddMoney()
    {
        _saveData.Money++;
        _text.text = _saveData.Money.ToString();
    }
    
    public void OnSaveBtnClicked()
    {
        _saver.Save(_saveData);
    }

    public void OnLoadBtnClicked()
    {
        _saveData = _saver.Load();
        _text.text = _saveData.Money.ToString();
    }
}
