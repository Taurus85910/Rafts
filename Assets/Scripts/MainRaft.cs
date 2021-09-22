using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MainRaft : MonoBehaviour
{
    [SerializeField] private int _gridSize;
    
    protected List<Raft> Rafts;
    protected List<Dweller> Dwellers;
    private bool _isIndependent  = true;

    public bool IsIndependent => _isIndependent;
    public List<Dweller> GetDwellers => Dwellers;
    public List<Raft> GetRafts => Rafts;

    public event Action RaftСaptured;
    
    protected virtual void Start()
    {
        Rafts = GetComponentsInChildren<Raft>().ToList();
        Dwellers = GetComponentsInChildren<Dweller>().ToList();
        transform.position = new Vector3(Mathf.RoundToInt(transform.position.x / _gridSize) * _gridSize, 0,
            Mathf.RoundToInt(transform.position.z / _gridSize) * _gridSize);
    }

    public bool IsDwellersAlive()
    {
        return Dwellers.Count(dweller => dweller.IsAlive) > 0;
    }
    
    public void BeginShootingDwellers()
    {
        Dwellers.ForEach(dweller => dweller.BeginShooting());
    }

    public void EndShootingDwellers()
    {
        Dwellers.ForEach(dweller => dweller.EndShooting());
    }

    public void ChangeDwellersColor()
    {
        Dwellers.ForEach(dweller => dweller.ChangeColor());
    }

    public void ChangeRaftsColor()
    {
        Rafts.ForEach(raft => raft.ChangeColor());
        _isIndependent = false;
        RaftСaptured?.Invoke();
    }

    public void CaptureRafts()
    {
        Rafts.ForEach(raft => raft.Capture());
    }

    public void GetDwellersWeapon()
    {
        Dwellers.ForEach(dweller => dweller.GetWeapon());
    }

    public void PutAwayDwellersWeapon()
    {
        Dwellers.ForEach(dweller => dweller.PutWeaponAway());
    }
}
