using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save
{
    public static void SetSample (string Key, string Name)
    {
        PlayerPrefs.SetString(Key,Name);
    }

    public static string GetSample (string KeyName)
    {
        return PlayerPrefs.GetString(KeyName);
    }
}
