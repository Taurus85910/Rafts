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
    private int _reward;
    
    public event Action<int> LevelChanged;
    public event Action<int> MoneyChanged;
    public event Action<int> RewardChanged;

    private void Awake()
    {
        _levels.ForEach(level => level.gameObject.SetActive(false));
        _playerPrefab.SetActive(false);
    }

    private void Start()
    {
        _saver.Save(_saveData);
        LoadLevel();
    }

    private void OpenEndLevelUI()
    {
        _endLevelUI.SetActive(true);
        _reward = (int)(_levels[_saveData.Level].Reward / 2 + _levels[_saveData.Level].Reward / 2 * 
            (Convert.ToDecimal(_mainGrid.CurrentFoundRaftsCount) / _mainGrid.GridsCount));
        RewardChanged?.Invoke(_reward);
    }

    public void CloseLevel()
    {
        _currentLevel.GetComponent<Level>().LevelCompleted -= OpenEndLevelUI;
        _endLevelUI.SetActive(false);
        _saveData.Money += _reward;
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
        MoneyChanged?.Invoke(_saveData.Money);
        LevelChanged?.Invoke(_saveData.Level+1);
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
