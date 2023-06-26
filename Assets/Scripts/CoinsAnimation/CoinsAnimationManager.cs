using Ebac.Core.Singleton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using DG.Tweening;

public class CoinsAnimationManager : Singleton<CoinsAnimationManager>
{
    public List<ItemCollactableCoin> items;

    [Header("Animation")]
    public float ScaleDuration = .2f;
    public float ScaleTimeBetweenPieces = .1f;
    public Ease ease = Ease.OutBack;

    private void Start()
    {
        items = new List<ItemCollactableCoin>();
    }

    public void RegisterCoin(ItemCollactableCoin i)
    {
        if (!items.Contains(i))
        {
            items.Add(i);
            i.transform.localScale = Vector3.one;
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            StartAnimations();
        }
    }

    public void StartAnimations()
    {
        StartCoroutine(ScalePiecesByTime());
    }

    IEnumerator ScalePiecesByTime()
    {
        foreach (var p in items)
        {
            p.transform.localScale = Vector3.one;
        }

        Sort();
        yield return null;

        for (int i = 0; i < items.Count; i++)
        {
            items[i].transform.DOScale(1, ScaleDuration).SetEase(ease);
            yield return new WaitForSeconds(ScaleTimeBetweenPieces);
        }
    }
    void Sort()
    {
        items = items.OrderBy(x => Vector3.Distance(this.transform.position, x.transform.position)).ToList();
    }
}