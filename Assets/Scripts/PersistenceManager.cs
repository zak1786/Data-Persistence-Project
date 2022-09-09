using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersistenceManager : MonoBehaviour
{
    public static PersistenceManager Instance;

    public static string playerName;
    public static string highScoreName;
    public static int highScore;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        MenuUIHandler.LoadHighScoreInfo();
    }
}
