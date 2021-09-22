using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerRaft : MainRaft
{
   protected override void Start()
   {
      base.Start();
      UpdateRaftCompound();
   }

   public void UpdateRaftCompound()
   {
      Rafts = AddNewElements<Raft>();
      Dwellers = AddNewElements<Dweller>();
   }

   private List<T> AddNewElements<T>() where T : MonoBehaviour
   {
      return GetComponentsInChildren<T>().ToList();
   }

   public void RestoreDwellersHealth()
   {
      Dwellers.ForEach(dweller => dweller.RestoreHealth());
   }
}
