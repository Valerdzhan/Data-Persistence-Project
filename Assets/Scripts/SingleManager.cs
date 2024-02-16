using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SingleManager : MonoBehaviour
{
    public static SingleManager Instance;
    public string playerName;
    public int bestScore = 0;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void OnChangePlayerName(string name)
    {
        playerName = name;
    }

    public void OnChangeBestScore(int score)
    {
        bestScore = score;
    }

    [Serializable]
    class SaveData
    {
        public string name;
        public int score;
    }

    public void SaveGame()
    {
        SaveData data = new SaveData
        {
            name = playerName,
            score = bestScore
        };

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadGame()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerName = data.name;
            bestScore = data.score;
        }
    }
}
