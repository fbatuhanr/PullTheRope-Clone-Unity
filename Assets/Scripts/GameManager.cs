using System;
using UnityEngine;

public enum GameMode { SinglePlayer=0, TwoPlayer=1 }
public enum SinglePlayerSide { TopSide=0, BotSide=1 }
public enum GameDifficulty { Easy=0, Medium=1, Hard=2 }

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public static GameMode? GameMode;
    public static SinglePlayerSide? SinglePlayerSide;
    public static GameDifficulty? GameDifficulty;
    
    public bool IsGameStart { get; set; }
    public bool IsGameOver { get; set; }

    public AudioSource gameOverWhistleSfxSource;

    private void Awake()
    {
        Instance = this;

        IsGameStart = false;
        IsGameOver = false;
    }
}