using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class TimeRequest : MonoBehaviour
{
    [SerializeField] private TimeStructure _timeStructure;
    public TimeStructure TimeStructure => _timeStructure;

    public delegate void TimeSelected();
    public static TimeSelected IsTimeSelected;
    public void GetTimeStructure()
    {
        _timeStructure = new TimeStructure();
        StartCoroutine(GetTimeData());  
    }
    IEnumerator GetTimeData()
    {
        UnityWebRequest www = UnityWebRequest.Get("https://tools.aimylogic.com/api/now?tz=Europe/Moscow&format=dd/MM/yyyy");
        yield return www.SendWebRequest();
        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            _timeStructure = CreateFromJSON(www.downloadHandler.text);
            IsTimeSelected?.Invoke();
        }
    }
    private static TimeStructure CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<TimeStructure>(jsonString);
        
    }
}
