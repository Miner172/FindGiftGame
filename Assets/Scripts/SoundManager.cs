using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    [Header("Sound")]
    [SerializeField] private AudioClip _jump;
    [SerializeField] private AudioClip _btn;
    [SerializeField] private AudioClip[] _end;
    [SerializeField] private AudioClip _giftFound;
    [SerializeField] private AudioClip _translate;
    [SerializeField] private AudioClip _timer;
    [SerializeField] private AudioClip[] _steps;
    [SerializeField] private AudioClip[] _backgroundMusic;
    private AudioSource _audio;

    [Header("Volume")]
    [SerializeField] private float _backgroundVolume;

    [Header("Other")]
    [SerializeField] private List<Button> _buttons;
    [SerializeField] private float _jumpDelay;
    [SerializeField] private float _moveDelay;
    private static float _jumpDelayStatic;
    private static float _stepDelayStatic;
    private static float _currentJumpTime;
    private static float _currentStepTime;

    private static AudioSource _audioStatic;
    private static AudioClip _jumpStatic;
    private static AudioClip[] _endStatic;
    private static AudioClip _giftFoundStatic;
    private static AudioClip _translateStatic;
    private static AudioClip _timerStatic;
    private static AudioClip[] _stepStatic;

    private bool _isEnable;

    private void OnEnable()
    {
        foreach (var button in _buttons)
            button.onClick.AddListener(BTNPress);
    }

    private void OnDisable()
    {
        foreach (var button in _buttons)
            button.onClick.RemoveListener(BTNPress);
    }

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
        _isEnable = true;
        _currentJumpTime = 0;

        _jumpDelayStatic = _jumpDelay;
        _stepDelayStatic = _moveDelay;

        _audioStatic = _audio;
        _jumpStatic = _jump;
        _endStatic = _end;
        _giftFoundStatic = _giftFound;
        _translateStatic = _translate;
        _timerStatic = _timer;
        _stepStatic = _steps;

        StartCoroutine(BackroundSound());
    }

    private void FixedUpdate()
    {
        _currentJumpTime += Time.deltaTime;
        _currentStepTime += Time.deltaTime;
    }

    public void OnOff()
    {
        if (_isEnable)
        {
            _audio.volume = 0;
            _isEnable = false;
        }
        else
        {
            _audio.volume = 1;
            _isEnable = true;
        }
    }

    public static void Jump()
    {
        if (_currentJumpTime >= _jumpDelayStatic)
        {
            _currentJumpTime = 0;
            _audioStatic.PlayOneShot(_jumpStatic);
        }
    }

    public static void Step()
    {
        if (_currentStepTime >= _stepDelayStatic)
        {
            _currentStepTime = 0;

            float randVolumeScale = Random.Range(0.1f, 0.5f);
            int randIndex = Random.Range(0, _stepStatic.Length);

            _audioStatic.PlayOneShot(_stepStatic[randIndex], randVolumeScale);
        }
    }
    public static void End() 
    {
        int randIndex = Random.Range(0, _endStatic.Length); 
        _audioStatic.PlayOneShot(_endStatic[randIndex]);
    }

    public static void Translate() { _audioStatic.PlayOneShot(_translateStatic); }
    public static void Timer() { _audioStatic.PlayOneShot(_timerStatic, 0.35f); }
    public static void GiftFound() { _audioStatic.PlayOneShot(_giftFoundStatic, 2.5f); }
    private void BTNPress() { _audio.PlayOneShot(_btn); }

    private IEnumerator BackroundSound()
    {
        int randNum = Random.Range(0, _backgroundMusic.Length);
        _audio.PlayOneShot(_backgroundMusic[randNum], _backgroundVolume);
        yield return new WaitForSecondsRealtime(_backgroundMusic[randNum].length);
        StartCoroutine(BackroundSound());
    }
}
