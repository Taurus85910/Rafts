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
   

    public void Save(SaveData data)
    {
        PlayerPrefs.SetInt(LEVEL_KEY, data.Level);
        PlayerPrefs.SetInt(MONEY_KEY, data.Money);
        PlayerPrefs.Save();
    }

    public SaveData Load()
    {
        var result = new SaveData();
        if (PlayerPrefs.HasKey(LEVEL_KEY))
        {
            result.Level = PlayerPrefs.GetInt(LEVEL_KEY);
        }
        if (PlayerPrefs.HasKey(MONEY_KEY))
        {
            result.Money = PlayerPrefs.GetInt(MONEY_KEY);
        }
        return result;
    }
}


