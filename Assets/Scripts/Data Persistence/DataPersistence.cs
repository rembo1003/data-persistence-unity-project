using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataPersistence : MonoBehaviour
{
   public static DataPersistence Instance;

   string PlayerName;
   string PlayerNameHS;
   int HighScore;
   void Awake()
   {
    if(Instance != null)
    {
        Destroy(gameObject);
        return;
    }

    Instance = this;
    DontDestroyOnLoad(gameObject);
   }

    public void PlayerNameHSLoad(string playerNameLoad)
   {
    DataPersistence.Instance.PlayerNameHS = playerNameLoad;
   }
   public void PlayerNameLoad(string playerNameLoad)
   {
    DataPersistence.Instance.PlayerName = playerNameLoad;
   }
   public void HighScoreLoad(int highScoreLoad)
   {
    DataPersistence.Instance.HighScore = highScoreLoad;
   }

   public int GetHighScore()
   {
    return HighScore;
   }

   public string GetPlayerName()
   {
    return PlayerName;
   }

   public string GetPlayerNameHS()
   {
    return PlayerNameHS;
   }

[System.Serializable]
   class SaveData
   {
    public string PlayerNameHS;
    public int PlayerHighScore;
   }

   public void SaveHighScore()
   {
    SaveData data = new SaveData();
    data.PlayerNameHS = PlayerNameHS;
    data.PlayerHighScore = HighScore;

    string json = JsonUtility.ToJson(data);

    File.WriteAllText(Application.persistentDataPath +"/savehighscore.json", json);
   }

   public void LoadHighScore()
   {
    string path = Application.persistentDataPath +"/savehighscore.json";
    if(File.Exists(path))
    {
        string json = File.ReadAllText(path);
        SaveData data = JsonUtility.FromJson<SaveData>(json);

        PlayerNameHS = data.PlayerNameHS;
        HighScore = data.PlayerHighScore;
    }
   }

}
