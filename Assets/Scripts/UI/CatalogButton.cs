using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class CatalogButton : MonoBehaviour
{
    [SerializeField] private GameObject _openableCatalog;
    [SerializeField] private Color _selectColor;
    [SerializeField] private Color _baseColor;

    private Image _image;

    public event Action CatalogOpened;
    
    private void Start()
    {
        _image = GetComponent<Image>();
    }

    public void OpenCatalog()
    {
        _openableCatalog.SetActive(true);
        _image.color = _selectColor;
        CatalogOpened?.Invoke();
    }

    public void CloseCatalog()
    {
        _openableCatalog.SetActive(false);
        _image.color = _baseColor;
    }
    
}
