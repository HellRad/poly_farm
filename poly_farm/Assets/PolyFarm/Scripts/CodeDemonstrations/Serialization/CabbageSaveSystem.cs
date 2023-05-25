using PolyFarm;
using System;
using System.Collections;
using UnityEngine;

namespace CodeDemo.Serialization
{
    public static class CabbageSaveSystem
    {
        public static void SaveAsJSONPlayerPrefs(MonoBehaviour someMono, CabbagesSaveData data, string prefsKeyName)
        {
            someMono.StartCoroutine(SaveAsJSONPlayerPrefs_CR(data, prefsKeyName));
        }

        static IEnumerator SaveAsJSONPlayerPrefs_CR(CabbagesSaveData data, string prefsKeyName)
        {
            var json = JsonUtility.ToJson(data);
            PlayerPrefs.SetString(prefsKeyName, json);
            yield return null;
        }

        public static void LoadFromJSONPlayerPrefs(MonoBehaviour someMono, string prefsKeyName, Action<CabbagesSaveData> OnLoadingEnded)
        {
            someMono.StartCoroutine(LoadFromJSONPlayerPrefs_CR(prefsKeyName, OnLoadingEnded));
        }

        static IEnumerator LoadFromJSONPlayerPrefs_CR(string prefsKeyName, Action<CabbagesSaveData> OnLoadingEnded)
        {
            var json = PlayerPrefs.GetString(prefsKeyName);

            if (string.IsNullOrEmpty(json))
            {
                Debug.LogWarning("Failed to load from JSON player prefs");
                OnLoadingEnded?.Invoke(null);
                yield return null;
            }

            var data = JsonUtility.FromJson<CabbagesSaveData>(json);
            OnLoadingEnded?.Invoke(data);
            yield return null;
        }
    }
}
