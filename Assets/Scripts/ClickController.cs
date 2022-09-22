using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

public class ClickController : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private int pullForce;
    public bool isAI;
    
    public void StartAICoroutine()
    {
        if (!isAI) return;
        StartCoroutine(PullAI());
    }

    private IEnumerator PullAI()
    {
        while (!GameManager.Instance.IsGameOver)
        {
            yield return new WaitForSeconds( AIClickDelayDurationByDifficulty() );
            PullTheRope();
        }
    }

    private float AIClickDelayDurationByDifficulty()
    {
        switch (GameManager.GameDifficulty)
        {
            case GameDifficulty.Easy: return Random.Range(0.25f, 0.75f); break;
            case GameDifficulty.Medium: return Random.Range(0.1f, 0.5f); break;
            case GameDifficulty.Hard: return Random.Range(0.05f, 0.3f); break;
            default: return Random.Range(0.1f, 0.5f); break;
        }
    }

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        if (isAI) return;
        PullTheRope();
    }
    private void PullTheRope()
    {
        RopeController.Instance.Position += pullForce;
    }
}