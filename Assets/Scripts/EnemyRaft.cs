using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyRaft : RaftBattleController
{
    [SerializeField] private List<Raft> _rafts;
    [SerializeField] private Material _newMaterial;
    
    public void RaftSurrender()
    {
        if (!IsDwellersAlive())
        {
            _rafts.ForEach(raft => raft.SetCaptureAvailable());
            _rafts.ForEach(raft => raft.gameObject.GetComponent<Renderer>().material = _newMaterial);
            enabled = false;
        }
    }
}
