using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SkinSelector : MonoBehaviour
{
    [SerializeField] private List<SelectButton> _buttons;
    [SerializeField] private List<GameObject> _models;
    [SerializeField] private Color _defaultColor;
    [SerializeField] private Color _unselectedColor;
    [SerializeField] private Color _selectColor;
    [SerializeField] private LevelLoader _levelLoader;

    private readonly Saver _saver = new Saver();

    public List<SelectButton> Buttons => _buttons;

    private void Start()
    {
        _buttons[0].BuySkin();
        if(SaveData.IsSecondUnitBought == 1)
            _buttons[1].BuySkin();
        PaintButton();
    }

    public void ChangeSkin(SelectButton selectButton)
    {
        if (!selectButton.Isbought) return;
        SaveData.CurrentUnitSkin = selectButton.SkinNumber;
        _models.ForEach(model => model.SetActive(false));
        selectButton.Model.SetActive(true);
        PaintButton();
        _saver.Save();
        _levelLoader.RestartLevel();
    }

    public void PaintButton()
    {
        foreach (SelectButton selectButton in _buttons)
        {
            if (selectButton.Isbought)
            {
                selectButton.Image.color = _defaultColor;
            }
            else
            {
                selectButton.Image.color = _unselectedColor;
            }
        }
        _buttons[SaveData.CurrentUnitSkin].Image.color = _selectColor;
    }
}
