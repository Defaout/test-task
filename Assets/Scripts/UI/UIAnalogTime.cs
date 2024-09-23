using DG.Tweening;
using UnityEngine;
using static UnityEngine.UI.GridLayoutGroup;

public class UIAnalogTime : MonoBehaviour
{
    [SerializeField] private GameObject _ArrowHour;
    [SerializeField] private GameObject _ArrowMinute;
    [SerializeField] private GameObject _ArrowSecond;
    [SerializeField] private int _secondOnMinutes = 60;
    [SerializeField] private int _secondOnHour = 3600;
    [SerializeField] private int _distanceToNextSecondDegrees = 6;
    [SerializeField] private int _distanceToNextMinuteDegrees = 6;
    [SerializeField] private int _distanceToNextHourDegrees = 30;
    public void SetTimeSecond(int second)
    {
        float corner = ((float)second / _secondOnMinutes) * 360;
        _ArrowSecond.transform.eulerAngles = new Vector3(0, 0, -corner);
        float endCorner = corner + _distanceToNextSecondDegrees;
        _ArrowSecond.transform.DORotate(new Vector3(0, 0, -endCorner), 1, RotateMode.Fast).SetEase(Ease.Linear);
    }
    public void SetTimMinutes( int minutes)
    {
        float corner = (((float)minutes / _secondOnMinutes) * 360);
        _ArrowMinute.transform.eulerAngles = new Vector3(0, 0, -corner);
        float endCorner = corner + _distanceToNextMinuteDegrees;
        _ArrowMinute.transform.DORotate(new Vector3(0, 0, -endCorner), _secondOnMinutes, RotateMode.Fast).SetEase(Ease.Linear);
    }
    public void SetTimeHour(int hour, int minutes)
    {
        float corner = (((float)hour / 12) * 360) + (_distanceToNextHourDegrees * ((float)minutes / _secondOnMinutes));
        _ArrowHour.transform.eulerAngles = new Vector3(0, 0, -corner);
        float endCorner = corner + _distanceToNextHourDegrees;
        _ArrowHour.transform.DORotate(new Vector3(0, 0, -endCorner), _secondOnHour, RotateMode.Fast).SetEase(Ease.Linear);
    }
}
