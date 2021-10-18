using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class GridPoint : MonoBehaviour
{
    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _image.color = Color.gray;
    }

    public void FillPointIcon()
    {
        _image.color = Color.green;
    }

    public void ClearPointIcon()
    {
        _image.color = Color.gray;
    }
}
