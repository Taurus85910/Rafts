using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


[RequireComponent(typeof(AlliedRaft))]
public class BattleController : MonoBehaviour
{
    [SerializeField] private RaftConnector _raftConnector;
    [SerializeField] private float _turnDuration;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private Material _newMaterial;
    private AlliedRaft _alliedRaft;
    
    private void Start()
    {
        _alliedRaft = GetComponent<AlliedRaft>();
    }

    private void OnEnable()
    {
        _raftConnector.RaftsConnected += OnRaftsConnected;
    }

    private void OnDisable()
    {
        _raftConnector.RaftsConnected -= OnRaftsConnected;
    }

    private void OnRaftsConnected(EnemyRaft enemyRaft)
    {
        _playerMovement.enabled = false;
        StartCoroutine(BattleStart(enemyRaft));
    }

    private IEnumerator BattleStart(EnemyRaft enemyRaft)
    {
        print("start");
        _alliedRaft.EnterDwellersBattle();
        enemyRaft.EnterDwellersBattle();
        while (_alliedRaft.IsDwellersAlive() && enemyRaft.IsDwellersAlive())
        {
            Attack(_alliedRaft.Dwellers,enemyRaft.Dwellers);
            Attack(enemyRaft.Dwellers,_alliedRaft.Dwellers);
            yield return new WaitForSeconds(_turnDuration);
        }
        _playerMovement.enabled = true;
        _alliedRaft.RemoveDeadDwellers();
        _alliedRaft.RestoreDwellersHeath();
        _alliedRaft.ExitDwellersBattle();
        enemyRaft.RaftSurrender();
        enemyRaft.RestoreDwellersHeath();
        enemyRaft.ExitDwellersBattle();
        AddEnemyDwellers(enemyRaft.Dwellers);
        print("end");
    }

    private void Attack(List<Dweller> Attackers, List<Dweller> defenders)
    {
        foreach (var dweller in Attackers)
        {
            if(dweller.IsDead)   
                continue;
            foreach (var enemyDweller in defenders)
            {
                if(enemyDweller.IsDead)   
                    continue;
                enemyDweller.ApplyDamage(dweller.Damage);
            }
        }
    }

    private void AddEnemyDwellers(List<Dweller> dwellers)
    {
        foreach (var dweller in dwellers)
        {
            dweller.SkinnedMeshRenderer.material = _newMaterial;
            _alliedRaft.Dwellers.Add(dweller);
        }
    }
}

