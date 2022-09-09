using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;
using System.IO;

public class MenuUIHandler : MonoBehaviour
{
    public GameObject nameInput;
    public string playerName;
    public GameObject bestScore;
    public GameObject highScoreName;
    public GameObject highScore;
    
    public void Start()
    {
        HighScoreInfo();
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        SaveHighScoreInfo();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void EnterName()
    {
        playerName = nameInput.GetComponent<Text>().text;
        PersistenceManager.playerName = playerName;
    }

    public void HighScoreInfo()
    {
        highScoreName.GetComponent<Text>().text = PersistenceManager.highScoreName;
        highScore.GetComponent<Text>().text = PersistenceManager.highScore.ToString();
    }

    [System.Serializable]
    class SaveData
    {
        public string highScoreName;
        public int highScore;
    }

    public void SaveHighScoreInfo()
    {
        SaveData data = new SaveData();
        data.highScoreName = PersistenceManager.highScoreName;
        data.highScore = PersistenceManager.highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public static void LoadHighScoreInfo()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            PersistenceManager.highScoreName = data.highScoreName;
            PersistenceManager.highScore = data.highScore;
        }
    }
}
