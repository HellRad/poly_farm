using System;
using System.IO;
using System.Text;
using UnityEngine.Serialization;
//using System.Text.Json.Serialization;
using System.Collections;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.Playables;
using System.Runtime.Serialization;

namespace CodeDemo.Serialization
{
    public class SerializationGameManager : MonoBehaviour
    {
        public CentralizedGameData gameData { get; private set; } = new CentralizedGameData();
        [SerializeField] bool serializeToPlayerPrefs;
        [SerializeField] bool serializeToJsonFile;
        [SerializeField] bool serializeToJsonPlayerPrefs;
        [SerializeField] bool serializeToBinaryFile;
        [SerializeField] bool useRealisticBinarySerialization;
        [SerializeField] string fileName = "SaveGame01";

        public SerializationGameManager Instance { get; private set; }

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Debug.LogWarning($"Additional game manager instance -{gameObject.name}- was deleted");
                Destroy(this.gameObject);
            }
        }

        [ContextMenu("CheckDataPath")]
        void CheckDataPath()
        {
            Debug.Log($"Persisten Path:{Application.persistentDataPath}");
        }

        [ContextMenu("SaveGameData")]
        void SaveGameData()
        {
            var gameData = new CentralizedGameData() { playerName = "bob" };

            var saveLoad = new SaveLoad();

            if (serializeToPlayerPrefs)
            {
                saveLoad.SaveGameInPlayerPrefs(gameData);
            }

            if (serializeToJsonFile)
            {
                var filePath = $"{Application.persistentDataPath}/{fileName}json";
                saveLoad.SaveAsJSON(gameData, filePath);
            }

            if (serializeToJsonPlayerPrefs)
            {
                var prefsKey = fileName;
                saveLoad.SaveAsJSONPlayerPrefs(this, gameData, prefsKey);
            }

            if (serializeToBinaryFile)
            {
                var filePath = $"{Application.persistentDataPath}/{fileName}.banana";
                saveLoad.SaveAsBinary(gameData, filePath);
            }

            if (useRealisticBinarySerialization)
            {
                var filePath = $"{Application.persistentDataPath}/{fileName}.potato";
                saveLoad.RealisicSaveBinaryFile(this, gameData, filePath);
            }
        }

        [ContextMenu("LoadGameData")]
        void LoadGameData()
        {
            var saveLoad = new SaveLoad();

            if (serializeToPlayerPrefs)
            {
                var prefsGameData = saveLoad.LoadGameFromPlayerPrefs();
            }

            if (serializeToJsonFile)
            {
                var filePath = $"{Application.persistentDataPath}/{fileName}.json";
                var jsonGameData = saveLoad.LoadJSON(filePath);
                Debug.Log($"loaded json game data. time: {jsonGameData.dateTime.ToString()}, name: {jsonGameData.playerName}");
            }

            if (serializeToJsonPlayerPrefs)
            {
                var prefsKey = fileName;
                saveLoad.LoadFromJSONPlayerPrefs(this, prefsKey, DebugResult);
            }

            if (serializeToBinaryFile)
            {
                var filePath = $"{Application.persistentDataPath}/{fileName}.banana";
                var binGameData = saveLoad.LoadBinary(filePath);
                Debug.Log($"loaded bin game data. time: {binGameData.dateTime.ToString()}, name: {binGameData.playerName}");
            }

            if (useRealisticBinarySerialization)
            {
                var filePath = $"{Application.persistentDataPath}/{fileName}.potato";
                saveLoad.RealisicLoadBinaryFile(this, filePath, DebugResult);
            }
        }

        void DebugResult(CentralizedGameData data)
        {
            Debug.Log($"loaded real bin game data. time: {data.dateTime.ToString()}, name: {data.playerName}");
        }
    }


    //data class
    [Serializable]
    public class CentralizedGameData
    {
        public DateTime dateTime;
        public string playerName;

        public CentralizedGameData()
        {
            dateTime = DateTime.Now;
        }
    }


    //saver
    public class SaveLoad
    {
        public void SaveGameInPlayerPrefs(CentralizedGameData gameData)
        {
            //parse values that are not supported by player prefs
            var dateTime = DateTime.Now.ToString();

            //add values to player prefs
            PlayerPrefs.SetString("DateTime", dateTime);
            PlayerPrefs.SetString("playerName", gameData.playerName);
            Debug.Log($"Saved in player prefs");
        }

        public CentralizedGameData LoadGameFromPlayerPrefs()
        {
            //gat values from player prefs
            var dateTimeString = PlayerPrefs.GetString("DateTime");
            var playerName = PlayerPrefs.GetString("playerName");

            //parse the string back to DateTime
            DateTime dateTime = DateTime.MinValue;
            if (!string.IsNullOrEmpty(dateTimeString) && DateTime.TryParse(dateTimeString, out DateTime result))
            {
                dateTime = result;
            }
            else { Debug.LogWarning("Failed to load dateTime from player prefs"); }

            Debug.Log($"Loaded from player prefs");

            return new CentralizedGameData() { dateTime = dateTime, playerName = playerName };
        }

        public void SaveAsJSON(CentralizedGameData gameData, string filePath)
        {
            var json = JsonUtility.ToJson(gameData);

            File.WriteAllText(filePath, json);

            Debug.Log($"Saved file at -{filePath}-:\n{json}");
        }

        public CentralizedGameData LoadJSON(string filePath)
        {
            var json = File.ReadAllText(filePath);

            Debug.Log($"Loading file at -{filePath}-:\n{json}");

            var playerData = JsonUtility.FromJson<CentralizedGameData>(json);

            return playerData;
        }

        public void SaveAsJSONPlayerPrefs(MonoBehaviour someMono, CentralizedGameData gameData, string prefsKeyName)
        {
            someMono.StartCoroutine(SaveAsJSONPlayerPrefs_CR(gameData, prefsKeyName));
        }

        IEnumerator SaveAsJSONPlayerPrefs_CR(CentralizedGameData gameData, string prefsKeyName)
        {
            var json = JsonUtility.ToJson(gameData);
            PlayerPrefs.SetString(prefsKeyName, json);
            yield return null;
        }

        public void LoadFromJSONPlayerPrefs(MonoBehaviour someMono, string prefsKeyName, Action<CentralizedGameData> OnLoadingEnded)
        {
            someMono.StartCoroutine(LoadFromJSONPlayerPrefs_CR(prefsKeyName, OnLoadingEnded));
        }

        IEnumerator LoadFromJSONPlayerPrefs_CR(string prefsKeyName, Action<CentralizedGameData> OnLoadingEnded)
        {
            var json= PlayerPrefs.GetString(prefsKeyName);

            if (string.IsNullOrEmpty(json))
            {
                Debug.LogWarning("Failed to load from JSON player prefs");
                OnLoadingEnded?.Invoke(null);
                yield return null;
            }

            var playerData = JsonUtility.FromJson<CentralizedGameData>(json);
            OnLoadingEnded?.Invoke(playerData);
            yield return null;
        }

        public void SaveAsBinary(CentralizedGameData gameData, string filePath)
        {
            var binaryFormatter = new BinaryFormatter();
            var fileStream = new FileStream(filePath, FileMode.Create);
            binaryFormatter.Serialize(fileStream, gameData);
            fileStream.Close();
            Debug.Log($"Saved binary file at -{filePath}-");
        }

        public CentralizedGameData LoadBinary(string filePath)
        {
            if (File.Exists(filePath))
            {
                var binaryFormatter = new BinaryFormatter();
                var fileStream = new FileStream(filePath, FileMode.Open);
                var gameData = (CentralizedGameData)binaryFormatter.Deserialize(fileStream);
                fileStream.Close();
                Debug.Log($"Loaded binary file at -{filePath}-");
                return gameData;
            }
            return null;
        }

        public void RealisicSaveBinaryFile(MonoBehaviour someMono, CentralizedGameData gameData, string filePath)
        {
            someMono.StartCoroutine(RealisicSaveBinaryFile_CR(gameData, filePath));
        }

        IEnumerator RealisicSaveBinaryFile_CR(CentralizedGameData gameData, string filePath)
        {
            using (var fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write))
            {
                var binaryFormatter = new BinaryFormatter();
                try
                {
                    binaryFormatter.Serialize(fileStream, gameData);
                    Debug.Log($"Saved binary file at -{filePath}-");
                }
                catch (SerializationException e)
                {
                    Debug.LogWarning($"Can't serialize file. Reason: {e}");
                }
            }
            yield return null;
        }

        public void RealisicLoadBinaryFile(MonoBehaviour someMono, string filePath, Action<CentralizedGameData> OnFileLoadingEnded)
        {
            someMono.StartCoroutine(RealisicLoadBinaryFile_CR(filePath, OnFileLoadingEnded));
        }

        IEnumerator RealisicLoadBinaryFile_CR(string filePath, Action<CentralizedGameData> OnFileLoadingEnded)
        {
            CentralizedGameData gameData = null;

            if (!File.Exists(filePath))
            {
                Debug.LogWarning($"Can't load file. File not found");
                OnFileLoadingEnded?.Invoke(null);
                yield return null;
            }

            using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                var binaryFormatter = new BinaryFormatter();
                try
                {
                    gameData = (CentralizedGameData)binaryFormatter.Deserialize(fileStream);
                    Debug.Log($"Loaded binary file at -{filePath}-");
                }
                catch (SerializationException e)
                {
                    Debug.LogWarning($"Can't deserialize file. Reason: {e}");
                }
            }
            OnFileLoadingEnded?.Invoke(gameData);
            yield return null;
        }
    }

    //centralized save game example
    public struct SaveGame
    {
        //header
        string name;
        string dateTime;
        string version;

        //body
        int playerPoints;
        string playerName;
        //etc.
    }
}