using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RaftBattleController : MonoBehaviour
{
    [SerializeField] protected List<Dweller> _dwellers;

    public List<Dweller> Dwellers => _dwellers;

    public bool IsDwellersAlive()
    {
        return _dwellers.Count(dweller => !dweller.IsDead) > 0;
    }

    public void EnterDwellersBattle()
    {
        Dwellers.ForEach(dweller => dweller.EnterBattle());
    }

    public void ExitDwellersBattle()
    {
        Dwellers.ForEach(dweller => dweller.ExitBattle());
    }
    
    public void RestoreDwellersHeath()
    {
        _dwellers.ForEach(dweller => dweller.ResetDweller());
    }
}
