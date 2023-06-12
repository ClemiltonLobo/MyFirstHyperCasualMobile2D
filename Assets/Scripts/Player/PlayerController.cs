using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;
using TMPro;
using DG.Tweening;

public class PlayerController : Singleton<PlayerController>
{
    //publics
    [Header("Lerp")]
    public Transform target;
    public float lerpSpeed = 1f;
    public float speed = 1f;
    public string tagToCheckEnemy = "Enemy";
    public string tagToCheckEndLine = "EndLine";
    public GameObject endScreen;

    [Header("Names PowerUps")]
    public TextMeshPro uiTextPowerUp;

    public bool invecible = true;

    [Header("Coin Setup")]
    public GameObject CoinCollector;

    [Header("Animation")]
    public AnimatorManager animatorManager;

    //privates
    private Vector3 _pos;
    private bool _canRun;
    private float _currentSpeed;
    private Vector3 _startPosition;
    private float _basicSpeedToAnimation = 7;

    /*private void Start()
    {
        _canRun = true;
    }*/

    private void Start()
    {
        _startPosition = transform.position;
        ResetSpeed();
    }

    void Update()
    {
        if(!_canRun) return;
        _pos = target.position;
        _pos.y = transform.position.y;
        _pos.z = transform.position.z;

        transform.position = Vector3.Lerp(transform.position, _pos, lerpSpeed * Time.deltaTime);
        transform.Translate(transform.forward * _currentSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == tagToCheckEnemy)
        {
            if (!invecible)
            {
                MoveBack(collision.transform);
                EndGame(AnimatorManager.AnimationType.DEAD);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == tagToCheckEndLine)
        {
            if(!invecible)EndGame();
        }
    }

    void MoveBack(Transform t)
    {
        t.DOMoveZ(1f, -1f).SetRelative();
    }

    private void EndGame(AnimatorManager.AnimationType animationType = AnimatorManager.AnimationType.IDLE)
    {
        _canRun = false;
        endScreen.SetActive(true);
        animatorManager.Play(animationType);
    }

    public void StartToRun()
    {
        _canRun=true;
        animatorManager.Play(AnimatorManager.AnimationType.RUN, _currentSpeed / _basicSpeedToAnimation);
    }

    #region PowerUps

    public void SetPowerUpText(string s)
    {
        uiTextPowerUp.text = s;
    }
    public void PowerUpSpeedUp(float f)
    {
        _currentSpeed = f;
    }

    public void SetInvencible(bool b = true)
    {
        invecible = b;
    }

    public void ResetSpeed()
    {
        _currentSpeed = speed;
    }

    public void ChangeFly(float amount, float duration, float animationDuration, Ease ease)
    {
        /*var p = transform.position;
        p.y = _startPosition.y + amount;
        transform.position = p;*/

        transform.DOMoveY(_startPosition.y + amount, animationDuration).SetEase(ease);//.onComplete(ResetFly);
        Invoke(nameof(ResetFly), duration);
    }

    public void ResetFly()
    {
        transform.DOMoveY(_startPosition.y, -1f);
    }

    public void changeCoinCollectorSize(float amount)
    {
        CoinCollector.transform.localScale = Vector3.one * amount;
    }
    #endregion
}