using System;
using UnityEngine;

public class TimerHold : MonoBehaviour
{
    public event Action<float> OnTimerValueChanged;
    public event Action OnTimerEnd;

    [SerializeField] private float _valueTimer;
    [SerializeField] private float _currentValueTimer;
    [SerializeField] private bool _isTimerStart;
    [SerializeField] private bool _isTimerBack;
    [SerializeField] private GestureMove _gestureMove;

    public float ValueTimer => _valueTimer;

    public float CurrentValueTimer => _currentValueTimer;

    private void OnEnable()
    {
        _gestureMove.HitTarget += TimerStart;
        _gestureMove.EndDrag += TimerBack;
    }

    private void OnDisable()
    {
        _gestureMove.HitTarget -= TimerStart;
        _gestureMove.EndDrag -= TimerBack;
    }

    private void Update()
    {
        if (_isTimerStart)
        {
            UpdateTimer();
            OnTimerValueChanged?.Invoke(_currentValueTimer);
        }
    }

    private void TimerStart()
    {
        _isTimerStart = true;
        _isTimerBack = false;
    }

    private void TimerBack()
        => _isTimerBack = true;


    private void UpdateTimer()
    {
        if (_isTimerBack)
        {
            _currentValueTimer -= Time.deltaTime;
        }
        else
        {
            _currentValueTimer += Time.deltaTime;
        }

        if (_currentValueTimer >= _valueTimer)
        {
            _isTimerStart = false;
            OnTimerEnd?.Invoke();
        }

        if (_currentValueTimer <= 0)
        {
            _isTimerStart = false;
        }
    }
}
