using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

public class ClickController : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private int pullForce;
    [SerializeField] private bool isAI;

    private void Start()
    {
        if (isAI) StartCoroutine(PullAI());
    }

    private IEnumerator PullAI()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(0.1f, 0.5f));
            PullTheRope();
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