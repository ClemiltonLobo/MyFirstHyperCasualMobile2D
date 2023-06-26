using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BounceHelper : MonoBehaviour
{
    [Header("Animation")]
    public float ScaleDuration = .2f;
    public float scaleBounce = .2f;
    public Ease ease = Ease.OutBack;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Bounce();
        }
    }
    public void Bounce()
    {
        transform.DOScale(scaleBounce, ScaleDuration).SetEase(ease).SetLoops(2, LoopType.Yoyo);
    }
}
