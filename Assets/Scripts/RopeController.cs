using UnityEditor.Build;
using UnityEngine;

public class RopeController : MonoBehaviour
{
    public static RopeController Instance;

    [Header("Game Players:")] 
    [SerializeField] private Transform moveObjects;
    [SerializeField] private float lerpSpeed = 5;

    [Header("Game Finish Indicator:")]
    [SerializeField] private Transform indicator;
    
    [Header("Game Finish Borders:")]
    [SerializeField] private Transform topBanner;
    [SerializeField] private Transform botBanner;

    public float Position { get; set; }
    private float _pullForceToPositionRound = 0.01f;

    private float _tangentAmount = 0.1f;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (!GameManager.Instance.IsGameStart || GameManager.Instance.IsGameOver) return;
        
        var targetValue = Vector3.up * Position * _pullForceToPositionRound;
        moveObjects.position = Vector3.Lerp(moveObjects.position, targetValue, lerpSpeed*Time.deltaTime);

        var isReachedTopBanner = topBanner.position.y - indicator.position.y <= _tangentAmount;
        var isReachedBotBanner = indicator.position.y - botBanner.position.y <= _tangentAmount;

        if (isReachedTopBanner || isReachedBotBanner)
        {
            if (isReachedTopBanner)
            {
                GameResultsUI.Instance.resultsTitle.SetText("<color=#EF4D47>Top</color> Player <br> WIN!");
            }
            else
            {
                GameResultsUI.Instance.resultsTitle.SetText("<color=#11A5F7>Bot</color> Player <br> WIN!");
            }
            GameManager.Instance.gameOverWhistleSfxSource.Play();
            GameResultsUI.Instance.Enable();
            GameManager.Instance.IsGameOver = true;
        }
    }
}