using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save
{

    public static void SetCurrentLevel(string key, string value)
    {
        PlayerPrefs.SetString(key, value);
    }


    public static string GetCurrentLevel(string keyName)
    {
        return PlayerPrefs.GetString(keyName);
    }

    public static void SetCurrentProgres(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
    }

    public static int GetCurrentProgres(string keyName)
    {
        return PlayerPrefs.GetInt(keyName);
    }


    public static void SetSample (string Key, string Name)
    {
        PlayerPrefs.SetString(Key,Name);
    }

    public static string GetSample (string KeyName)
    {
        return PlayerPrefs.GetString(KeyName);
    }

    public static void ResetAllKey()
    {
        PlayerPrefs.DeleteAll();
    }

    public static void DelateKey(string key)
    {
        PlayerPrefs.DeleteKey(key);
    }
}
