using System;
using System.Collections;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    [SerializeField] private TimeRequest _timeRequest;
    [SerializeField] private DateTime _time;
    [SerializeField] private int _hourForSelected;
    [SerializeField] private int _minuteForSelected;

    public delegate void Time();
    public static Time NextSecond;
    public static Time NewHour;
    public static Time NewMinute;

    private void OnEnable()
    {
        TimeRequest.IsTimeSelected += IsTimeSelected;
    }
    private void OnDisable()
    {
        TimeRequest.IsTimeSelected -= IsTimeSelected;
    }
    public DateTime TimeDate => _time;
    private void Start()
    {
        StartRequestTime();
    }
    private void StartRequestTime()
    {
        _timeRequest.GetTimeStructure();
    }
    private void IsTimeSelected()
    {
        _hourForSelected = _timeRequest.TimeStructure.hour;
        _minuteForSelected = _timeRequest.TimeStructure.minute;
        _time = new DateTime(
                _timeRequest.TimeStructure.year,
                _timeRequest.TimeStructure.month,
                _timeRequest.TimeStructure.day,
                _timeRequest.TimeStructure.hour,
                _timeRequest.TimeStructure.minute,
                _timeRequest.TimeStructure.second
                );
        NewHour?.Invoke();
        NewMinute?.Invoke();
        StartCoroutine(NextSecondTime());
    }
    private IEnumerator NextSecondTime()
    {
        yield return new WaitForSeconds(1);
        _time=_time.AddSeconds(1);
        if (_time.Hour == _hourForSelected)
        {
            NextSecond?.Invoke();
            if(_time.Minute!= _minuteForSelected)
            {
                _minuteForSelected = _time.Minute;
                NewMinute?.Invoke();
            }
            StartCoroutine(NextSecondTime());
        }
        else
        {
            StartRequestTime();

        }
    }
}
