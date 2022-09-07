using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;
using TMPro;

public class MenuUIHandler : MonoBehaviour
{
    public GameObject nameInput;
    public string playerName;
    
    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
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
        PersistenceManager.Instance.playerName = playerName;
    }
}
