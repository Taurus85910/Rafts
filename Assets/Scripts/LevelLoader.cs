using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private List<Level> _levels; 
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private GameObject _shopButton;
    [SerializeField] private GameObject _endLevelUI;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private GameObject _restartPanel;
    [SerializeField] private GridPointsController _gridPointsController;
    
    private Saver _saver = new Saver();
    private SaveData _saveData = new SaveData();
    private GameObject _currentLevel;
    private GameObject _currentPlayerPrefab;
    private MainGrid _mainGrid;
    
    public event Action<int> LevelLoaded;
    public event Action<int> LevelClosed;
    
    private void Start()
    {
        LoadLevel();
    }

    private void OpenEndLevelUI()
    {
        _endLevelUI.SetActive(true);
    }

    public void CloseLevel()
    {
        _currentLevel.GetComponent<Level>().LevelCompleted -= OpenEndLevelUI;
        _endLevelUI.SetActive(false);
        _saveData.Money += _levels[_saveData.Level].Reward;
        _saveData.Level++;
        _saver.Save(_saveData);
        Destroy(_currentLevel);
        Destroy(_currentPlayerPrefab);
       
        _mainGrid.gameObject.SetActive(false);
        LoadLevel();
    }

    public void RestartLevel()
    {
        _restartPanel.SetActive(false);
        Destroy(_currentLevel);
        Destroy(_currentPlayerPrefab);
        _currentLevel.GetComponent<Level>().LevelCompleted -= OpenEndLevelUI;
        LoadLevel();
    }

    private void LoadLevel()
    {
        _gridPointsController.ClearPointsIcon();
        _endLevelUI.SetActive(false);
        _shopButton.SetActive(true);
        _saveData = _saver.Load();
        LevelClosed?.Invoke(_saveData.Money);
        LevelLoaded?.Invoke(_saveData.Level+1);
        _currentLevel = Instantiate(_levels[_saveData.Level].gameObject);
        _currentLevel.SetActive(true);
        _currentLevel.GetComponent<Level>().LevelCompleted += OpenEndLevelUI;
        _currentPlayerPrefab = Instantiate(_playerPrefab);
        _currentPlayerPrefab.SetActive(true);
        _canvas.worldCamera = _currentPlayerPrefab.GetComponentInChildren<Camera>();
        _currentPlayerPrefab.GetComponentsInChildren<MainGrid>().ToList().ForEach(grid => grid.gameObject.SetActive(true));
        _mainGrid = _currentPlayerPrefab.GetComponentsInChildren<MainGrid>().ToList()[_saveData.Level];
        _mainGrid.ResetFoundRaftsCount();
        _currentPlayerPrefab.GetComponentsInChildren<MainGrid>().ToList().ForEach(grid => grid.gameObject.SetActive(false));
        _mainGrid.gameObject.SetActive(true);
       
    }
}
