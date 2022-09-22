using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameResultsUI : MonoBehaviour
{
    public static GameResultsUI Instance;

    [SerializeField] private RectTransform gameResultsBg;
    public TextMeshProUGUI resultsTitle;
    
    private void Awake()
    {
        Instance = this;
    }

    public void Enable()
    {
        gameResultsBg.DOScale(Vector3.one, 0.2f);
    }

    public void Restart_Button()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void PlayAgain_Button()
    {
        GameManager.GameMode = null;
        GameManager.SinglePlayerSide = null;
        GameManager.GameDifficulty = null;
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
