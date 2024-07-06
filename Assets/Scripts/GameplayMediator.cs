using UnityEngine;
using UnityEngine.UI;

public class GameplayMediator : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TimerHold _timerHold;

    private void OnEnable()
    {
        _timerHold.OnTimerValueChanged += UpdateSliderValue;
    }

    private void OnDisable()
    {
        _timerHold.OnTimerValueChanged -= UpdateSliderValue;
    }

    private void UpdateSliderValue(float currentValue)
    {
        _slider.value = currentValue / _timerHold.ValueTimer;
    }
}
