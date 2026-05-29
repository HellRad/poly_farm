using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using CodeDemo;
using UnityEditor;
using UnityEngine.TestTools;
using System.Collections;

public class SearchForChickenPrefab
{
    [UnityTest]
    public IEnumerator CheckPrefabAccessTime()
    {
        string prefabName = "Chicken";

        GameObject[] foundPrefabs = FindPrefabsByName(prefabName);

        Debug.Log($"Prefabs found {foundPrefabs.Length}");

        Assert.GreaterOrEqual(foundPrefabs.Length, 1, $"Found no prefabs with name: {prefabName}");
        yield return null;
    }

    /// <summary>
    /// Looks for assets of a certain type. If the asset type is "GameObject" this function will return prefabs.
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    private GameObject[] FindPrefabsByName(string name)
    {
        List<GameObject> foundGameObjects = new List<GameObject>();
        string[] guids = AssetDatabase.FindAssets($"t:prefab");

        for (int i = 0; i < guids.Length; i++)
        {
            string assetPath = AssetDatabase.GUIDToAssetPath(guids[i]);
            GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(assetPath);
            if (prefab != null && prefab.name == name)
            {
                foundGameObjects.Add(prefab);
            }
        }
        return foundGameObjects.ToArray();
    }
}