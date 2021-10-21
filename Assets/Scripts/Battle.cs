using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Battle : MonoBehaviour
{
    [SerializeField] private RaftConnector _raftConnector;
    [SerializeField] private float _turnDuration;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private CameraZoomer _cameraZoomer;
    [SerializeField] private GameObject _restartPanel;

    private PlayerRaft _playerRaft;
    
    private void Start()
    {
        _playerRaft = GetComponent<PlayerRaft>();
    }

    private void OnEnable()
    {
        _raftConnector.RaftConnected += OnRaftConnected;
    }

    private void OnDisable()
    {
        _raftConnector.RaftConnected -= OnRaftConnected;
    }

    private void OnRaftConnected(MainRaft mainRaft)
    {
        StartCoroutine(BattleProcesses(mainRaft));
    }

    private IEnumerator BattleProcesses(MainRaft mainRaft)
    {
        _playerRaft.GetDwellersWeapon();
        _playerRaft.BeginShootingDwellers();
        mainRaft.GetDwellersWeapon();
        mainRaft.BeginShootingDwellers();
        _playerMovement.enabled = false;
        _cameraZoomer.Zoom();
        mainRaft.CaptureRafts();
        while (_playerRaft.IsDwellersAlive() && mainRaft.IsDwellersAlive())
        {
            yield return new WaitForSeconds(_turnDuration);
            Attack(_playerRaft.GetDwellers, mainRaft.GetDwellers);
            Attack(mainRaft.GetDwellers, _playerRaft.GetDwellers);
            
        }
       
        yield return new WaitForSeconds(_turnDuration);

        if (_playerRaft.IsDwellersAlive())
        {
            mainRaft.EndShootingDwellers();
            _playerRaft.EndShootingDwellers();
            mainRaft.PutAwayDwellersWeapon();
            _playerRaft.PutAwayDwellersWeapon();
            mainRaft.ChangeRaftsColor();
            mainRaft.ChangeDwellersColor();
            _raftConnector.Connecting(mainRaft);
            _playerRaft.UpdateRaftCompound();
            _playerRaft.RestoreDwellersHealth();
            _playerMovement.enabled = true;
            _cameraZoomer.Unzoom();
            
        }
        else
        {
            _restartPanel.SetActive(true);
        }
    }

    private void Attack(List<Dweller> attackers,List<Dweller> defenders)
    {
        int deathIndent = 0;
        
        
        for (int i = 0; i < attackers.Count; i++)
        {
            if (attackers[i].IsAlive)
            {
                int currentTarget = Mathf.Clamp(i + deathIndent - (i / defenders.Count) *  (defenders.Count),0,defenders.Count-1);

                if (defenders[currentTarget].IsAlive)
                {
                    attackers[i].DwellerBody.transform.LookAt(defenders[currentTarget].DwellerBody.transform);
                    defenders[currentTarget].AppleDamage(attackers[i].Shoot(defenders[currentTarget].DwellerBody.transform));
                    attackers[i].DwellerBody.AlignBody();
                }
                else
                {
                    if (defenders.Count - 1 != deathIndent)
                    {
                        deathIndent++;
                        i--;
                    }
                }
            }
            else
            {
                deathIndent--;
            }

        }
    }
}
