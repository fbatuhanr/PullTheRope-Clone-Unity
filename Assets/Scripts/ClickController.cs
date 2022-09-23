using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

public class ClickController : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private int pullForce;
    public bool isAI;

    [Header("Click Effects: ")] 
    [SerializeField] private AudioSource yellSfxSource;
    [SerializeField] private Transform yellParticlesParent;
    [SerializeField] private GameObject yellParticle;

    [SerializeField] private List<SpriteRenderer> yellParticlesList;

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
            
            YellSfx();
            YellParticle();
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

        YellSfx();
        YellParticle();
        PullTheRope();
    }
    private void PullTheRope()
    {
        RopeController.Instance.Position += pullForce;
    }

    private void YellParticle()
    {
        var tempYellParticles = new List<SpriteRenderer>(yellParticlesList);

        foreach (var item in tempYellParticles) item.enabled = false;
            
        var yellSpawnCount = Random.Range(1, 4);
        for (var i = 0; i < yellSpawnCount; i++)
        {
            var randomYellParticleIndex = Random.Range(0, tempYellParticles.Count);
            var randomYellParticleSprite = tempYellParticles[randomYellParticleIndex];

            randomYellParticleSprite.enabled = true;
            StartCoroutine(DisableRandomYell(randomYellParticleSprite));

            tempYellParticles.RemoveAt(randomYellParticleIndex);
        }
    }
    private IEnumerator DisableRandomYell(SpriteRenderer thisRandomYell)
    {
        yield return new WaitForSeconds(0.5f);
        thisRandomYell.enabled = false;
    }

    private void YellSfx()
    {
        yellSfxSource.Play();
    }
}