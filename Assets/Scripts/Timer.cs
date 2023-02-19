using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class Timer : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Text _timerText;
    private Animator _anim;
    private float _currentTimeSeconds;
    private bool _isGoing;
    private bool _flag;

    public event UnityAction TimeOutEvent;

    private void Start()
    {
        _timerText = GetComponent<Text>();
        _anim = GetComponent<Animator>();

        _flag = true;
    }

    private void FixedUpdate()
    {
        if (_isGoing)
        {
            _currentTimeSeconds -= Time.deltaTime * _speed;
            UpdateText();

            if (_currentTimeSeconds <= 10)
                End();

            if (_currentTimeSeconds <= 0)
                TimeOut();
        }
    }

    private void End()
    {
        if (_flag)
        {
            _flag = false;
            SoundManager.Timer();
        }
    }

    public void StartTimer(float time, Gamemode gamemode)
    {
        _currentTimeSeconds = time;
        _isGoing = true;

        switch (gamemode)
        {
            case Gamemode.Easy:
                _anim.SetTrigger("Five");
                break;
            case Gamemode.Medium:
                _anim.SetTrigger("Second");
                break;
            case Gamemode.Hard:
                _anim.SetTrigger("One");
                break;
            default:
                break;
        }
    }

    private void UpdateText()
    {
        TimeSpan ts = TimeSpan.FromSeconds(_currentTimeSeconds);
        string time = string.Format("{1}м. {0}с.", ts.Seconds, ts.Minutes);

        _timerText.text = $"{time}";
    }

    private void TimeOut()
    {
        _timerText.text = "¬рем€ вышло";
        _isGoing = false;

        TimeOutEvent?.Invoke();
    }
}
