using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectButton : MonoBehaviour
{
    [SerializeField] private GameObject _model;
    [SerializeField] private int _skinNumber;

    private bool _isbought = false;
    private Image _image;

    public GameObject Model => _model;

    public Image Image => _image;

    public int SkinNumber => _skinNumber;

    public bool Isbought => _isbought;

    private void Start()
    {
        _image = GetComponent<Image>();
    }

    public void BuySkin()
    {
        _isbought = true;
    }
}
