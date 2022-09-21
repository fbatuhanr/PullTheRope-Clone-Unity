using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool IsGameover { get; set; }

    private void Awake()
    {
        Instance = this;
        IsGameover = false;
    }
}