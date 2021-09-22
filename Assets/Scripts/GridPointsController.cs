using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GridPointsController : MonoBehaviour
{
    private List<GridPoint> _gridPoints;

    private void Start()
    {
        _gridPoints = GetComponentsInChildren<GridPoint>().ToList();
        _gridPoints.ForEach(point => point.gameObject.SetActive(false));
    }

    public void InitGridPoints(int count)
    {
        _gridPoints.ForEach(point => point.gameObject.SetActive(false));
        for (int i = 0; i < count; i++)
        {
            _gridPoints[i].gameObject.SetActive(true);
        }
    }

    public void FillPointsIcon(int count)
    {
        for (int i = 0; i < count; i++)
        {
            _gridPoints[i].FillPointIcon();
        }
    }

    public void ClearPointsIcon()
    {
        _gridPoints.ForEach(point => point.ClearPointIcon());
    }
}
