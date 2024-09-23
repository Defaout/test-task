using UnityEngine;

public class InfoUITimer : MonoBehaviour
{
    [SerializeField] private TimeController _controller;
    [SerializeField] private UIDigitalTime _uIDigitalTime;
    [SerializeField] private UIAnalogTime _uIAnalogTime;
    [SerializeField] private string _time;
    private void OnEnable()
    {
        TimeController.NextSecond += SetDigitalTime;
        TimeController.NewHour += SetAnalogHour;
        TimeController.NewMinute += SetAnalogMinute;
    }
    private void OnDisable()
    {
        TimeController.NextSecond -= SetDigitalTime;
        TimeController.NewHour += SetAnalogHour;
        TimeController.NewMinute += SetAnalogMinute;
    }
    private void SetDigitalTime()
    {
        _time = _controller.TimeDate.ToLongTimeString();
        int seconds = _controller.TimeDate.Second;
        _uIAnalogTime.SetTimeSecond(seconds);
        _uIDigitalTime.SetTime(_time);
    }    
    private void SetAnalogMinute()
    {
        int minutes = _controller.TimeDate.Minute;
        _uIAnalogTime.SetTimMinutes(minutes);
    }
    private void SetAnalogHour()
    {
        int hour = _controller.TimeDate.Hour;
        int minutes= _controller.TimeDate.Minute;
        _uIAnalogTime.SetTimeHour(hour, minutes);
    }


}
