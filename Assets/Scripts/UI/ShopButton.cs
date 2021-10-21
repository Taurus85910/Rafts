using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{
   [SerializeField] private CatalogButton _catalogButton;
   [SerializeField] private Color _availableColor;
   [SerializeField] private Color _defaultColor;
   [SerializeField] private int _baseCost;
   [SerializeField] private TMP_Text _text;
   [SerializeField] private SkinSelector _skinSelector;
   
   private int _costModifier = 1;
   private List<SelectButton> _buttons;
   private Image _image;
   private readonly Saver _saver = new Saver();
   
   private void OnEnable()
   {
      _catalogButton.CatalogOpened += OnCatalogOpened;
   }

   private void OnDisable()
   {
      _catalogButton.CatalogOpened -= OnCatalogOpened;
   }

   private void Start()
   {
      _buttons = _skinSelector.Buttons;
   }

   private void OnCatalogOpened()
   {
      _image = GetComponent<Image>();
      _image.color = _defaultColor;
      _text.text = (_costModifier * _baseCost).ToString();
      if (_costModifier * _baseCost <= SaveData.Money)
      {
         _image.color = _availableColor;
      }
   }

   public void BuySkin()
   {
      if (_costModifier * _baseCost <= SaveData.Money)
      {
         _buttons[1].BuySkin();
         SaveData.Money -= _costModifier * _baseCost;
         SaveData.IsSecondUnitBought = 1;
         _saver.Save();
         _costModifier++;
         _skinSelector.PaintButton();
      }
      OnCatalogOpened();
   }

}
