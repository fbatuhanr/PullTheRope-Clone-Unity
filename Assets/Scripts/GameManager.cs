using System;
using UnityEngine;

public enum GameMode { SinglePlayer=0, TwoPlayer=1 }
public enum SinglePlayerSide { TopSide=0, BotSide=1 }
public enum GameDifficulty { Easy=0, Medium=1, Hard=2 }

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public static GameMode? GameMode = null;
    public static SinglePlayerSide? SinglePlayerSide = null;
    public static GameDifficulty? GameDifficulty = null;
    
    public bool IsGameStart { get; set; }
    public bool IsGameOver { get; set; }


    private const string GameModeKey = "GameMode";
    private const string GameDifficultyKey = "GameDifficulty";
    private void Awake()
    {
        Instance = this;

        IsGameStart = false;
        IsGameOver = false;
    }

    private void Start()
    {
    }

    // public void SetPlayerPrefs()
    // {
    //     PlayerPrefs.SetInt(GameModeKey, (int)gameMode);
    //     PlayerPrefs.SetInt(GameDifficultyKey, (int)gameDifficulty);
    // }
    //
    // public bool GetPlayerPrefs()
    // {
    //     if (!PlayerPrefs.HasKey(GameModeKey) && !PlayerPrefs.HasKey(GameDifficultyKey)) return false;
    //
    //     gameMode = (GameMode) PlayerPrefs.GetInt(GameModeKey);
    //     gameDifficulty = (GameDifficulty) PlayerPrefs.GetInt(GameDifficultyKey);
    //
    //     if (gameMode == GameMode.SinglePlayer)
    //     {
    //         
    //     }
    //
    //     IsGameStart = true;
    //     return true;
    // }
}