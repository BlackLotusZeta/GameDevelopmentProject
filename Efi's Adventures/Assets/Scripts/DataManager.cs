//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class DataManager : MonoBehaviour
//{

//    public float[] position;
//    public int health;
//    public int score;

//    public void SaveGame()
//    {
//        PlayerData playerData = new PlayerData();
//        playerData.position = new float[] { playerDataTransform.position.x, playerDataTransform.position.y, playerDataTransform.position.z };
//        playerData.health = GameManager.health;
//        playerData.score = ScoreManager.scoreCount;

//        string json = JsonUtility.ToJson(playerData);
//        string path = Application.persistentDataPath + "/playerData.json";
//        System.ID.File.WriteAllText(path, json);
//    }

//    public void LoadGame()
//    {
//        string path = Application.persistentDataPath + "/playerData.json";
//        if (File.Exists(path))
//        {
//            string json = System.ID.File.ReadAllText(path);
//            PlayerData loadedData = JsonUtility.FromJson<PlayerData>(json);

//            playerTransform.position = new Vector3(loadedData.position[0], loadedData.position[1], loadedData.position[2]);
//            Vector3 LoadedPosition = new Vector3(loadedData.position[0], loadedData.position[1], loadedData.position[2]);
            
//            playerTransform.position = LoadedPosition;
//            GameManager.health = loadedData.health;
//            ScoreManager.scoreCount = loadedData.score;
//        }
//        else
//        {
//            Debug.LogWarning("File not found");
//        }
//    }
//}
