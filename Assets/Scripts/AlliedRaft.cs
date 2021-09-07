using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AlliedRaft : RaftBattleController
{
    public void RemoveDeadDwellers()
    {
        _dwellers = _dwellers.Where(dweller => !dweller.IsDead).ToList();
    }
}
