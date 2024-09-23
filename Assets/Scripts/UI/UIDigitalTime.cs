using TMPro;
using UnityEngine;

public class UIDigitalTime : MonoBehaviour
{
    [SerializeField] private TMP_Text _time;

    public void SetTime(string time)
    {
        _time.text= time;
    }
}
