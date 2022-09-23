using DG.Tweening;
using UnityEngine;

public class GameConfigUI : MonoBehaviour
{
    public static GameConfigUI Instance;

    [SerializeField] private RectTransform selectionsParent;

    [SerializeField] private RectTransform singleOrTwoPlayerSelection;
    [SerializeField] private RectTransform singlePlayerSideSelection, singlePlayerDifficultSelection;

    [SerializeField] private ClickController topClickController, botClickController;
    
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Debug.Log($"Game Mode: {GameManager.GameMode}");
        Debug.Log($"Single Player Side: {GameManager.SinglePlayerSide}");
        Debug.Log($"Game Difficulty: {GameManager.GameDifficulty}");

        if (GameManager.GameMode == GameMode.TwoPlayer)
        {
            DisableGameConfigAndStartTheGame();
            return;
        }

        if (GameManager.GameMode == null || GameManager.SinglePlayerSide == null || GameManager.GameDifficulty == null)
        {
            selectionsParent.DOScale(Vector3.one, 0.2f);
        }
        else
        {
            if (GameManager.SinglePlayerSide == SinglePlayerSide.TopSide)
            {
                botClickController.isAI = true;
                botClickController.StartAICoroutine();
            }
            else
            {
                topClickController.isAI = true;
                topClickController.StartAICoroutine();
            }

            DisableGameConfigAndStartTheGame();
        }
    }

    public void SinglePlayerSelection_Button()
    {
        GameManager.GameMode = GameMode.SinglePlayer;
        
        singleOrTwoPlayerSelection.DOScale(Vector3.zero, 0.2f);
        singlePlayerDifficultSelection.DOScale(Vector3.one, 0.2f);
    }

    public void SinglePlayerSelectionDifficulty_Buttons(int difficultyIndex)
    {
        GameManager.GameDifficulty = (GameDifficulty)difficultyIndex;
        
        singlePlayerDifficultSelection.DOScale(Vector3.zero, 0.2f);
        singlePlayerSideSelection.DOScale(Vector3.one, 0.2f);
    }
    
    public void SinglePlayerSelectionTopSide_Button()
    {
        GameManager.SinglePlayerSide = SinglePlayerSide.TopSide;
        botClickController.isAI = true;
        botClickController.StartAICoroutine();
    }
    public void SinglePlayerSelectionBotSide_Button()
    {
        GameManager.SinglePlayerSide = SinglePlayerSide.BotSide;
        topClickController.isAI = true;
        topClickController.StartAICoroutine();
    }
    
    
    public void TwoPlayerSelection_Button()
    {
        GameManager.GameMode = GameMode.TwoPlayer;
        DisableGameConfigAndStartTheGame();
    }

    public void DisableGameConfigAndStartTheGame()
    {
        selectionsParent.DOScale(Vector3.zero, 0.2f);
        GameManager.Instance.IsGameStart = true;
    }
}
