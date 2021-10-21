using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class Saver
{ 
    private const string LEVEL_KEY = "m_level";
    private const string MONEY_KEY = "m_money";
    private const string UNITSKIN_KEY = "m_unitskin";
    private const string ISSECONDUNITBOUGTH_KEY = "m_issecondunitbought";

    public void Save()
    {
        PlayerPrefs.SetInt(LEVEL_KEY, SaveData.Level);
        PlayerPrefs.SetInt(MONEY_KEY, SaveData.Money);
        PlayerPrefs.SetInt(UNITSKIN_KEY,SaveData.CurrentUnitSkin);
        PlayerPrefs.SetInt(ISSECONDUNITBOUGTH_KEY,SaveData.IsSecondUnitBought);
        PlayerPrefs.Save();
    }

    public void Load()
    {
        if (PlayerPrefs.HasKey(LEVEL_KEY))
        {
            SaveData.Level = PlayerPrefs.GetInt(LEVEL_KEY);
        }
        if (PlayerPrefs.HasKey(MONEY_KEY))
        {
            SaveData.Money = PlayerPrefs.GetInt(MONEY_KEY);
        }
        if (PlayerPrefs.HasKey(UNITSKIN_KEY))
        {
            SaveData.CurrentUnitSkin = PlayerPrefs.GetInt(UNITSKIN_KEY);
        }
        if (PlayerPrefs.HasKey(ISSECONDUNITBOUGTH_KEY))
        {
            SaveData.IsSecondUnitBought = PlayerPrefs.GetInt(ISSECONDUNITBOUGTH_KEY);
        }
    }
}


