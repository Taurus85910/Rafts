using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Level : MonoBehaviour
{
   [SerializeField] private List<MainRaft> _rafts;

   [SerializeField] private int _reward;

   public int Reward => _reward;

   public event Action LevelCompleted;

   private void OnEnable()
   {
      _rafts.ForEach(raft => raft.RaftСaptured += EndLevelChecker);
   }

   private void OnDisable()
   {
      _rafts.ForEach(raft => raft.RaftСaptured -= EndLevelChecker);
   }

   private void EndLevelChecker()
   {
      if (_rafts.Count(raft => raft.IsIndependent) == 0)
      {
         LevelCompleted?.Invoke();
      }
   }
   
}
