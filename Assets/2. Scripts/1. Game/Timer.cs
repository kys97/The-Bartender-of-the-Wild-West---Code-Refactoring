using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    Slider TimerSlider;

    private void OnEnable()
    {
        GameManager.OnUIInit += Init;
    }

    private void Init()
    {
        TimerSlider = GetComponent<Slider>();
        TimerSlider.maxValue = 60;
        TimerSlider.minValue = 0;
        TimerSlider.value = TimerSlider.maxValue;
    }

    private void OnDisable()
    {
        GameManager.OnUIInit -= Init;
    }
}
