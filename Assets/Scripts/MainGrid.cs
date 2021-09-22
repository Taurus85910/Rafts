using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MainGrid : MonoBehaviour
{
    [SerializeField] private GridPointsController _gridPointsController;
    
    private List<Grid> _grids;
    private int _currentFoundRaftsCount = 0;
    
    private void OnEnable()
    {
        _grids.ForEach(grid => grid.RaftFound += OnRaftFound);
    }

    private void OnDisable()
    {
        _grids.ForEach(grid => grid.RaftFound -= OnRaftFound);
    }

    private void Awake()
    {
        _grids = GetComponentsInChildren<Grid>().ToList();
        _grids.ForEach(grid => grid.gameObject.SetActive(true));
    }

    public void ResetFoundRaftsCount()
    {
        _currentFoundRaftsCount = 0;
        _gridPointsController.InitGridPoints(_grids.Count);
    }

    private void OnRaftFound()
    {
        _currentFoundRaftsCount++;
        _gridPointsController.FillPointsIcon(_currentFoundRaftsCount);
    }
    
}
