using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class WebManager : MonoBehaviour
{
    public event Action DataReceived;

    [SerializeField] private string _targetURL;
    [SerializeField] private string _nameCloneGame;

    private string _data;
    public string Data => _data;

    public void Initialize()
    {
        StartCoroutine(SendData());
    }

    public void HandleQueryString(string queryString)
    {
#if UNITY_WEBGL
        _targetURL = queryString;
        Debug.Log("Received query string: " + _targetURL);
#endif
        Debug.Log("Received query string: " + _targetURL);
    }

    private IEnumerator SendData()
    {
        WWWForm form = new WWWForm();

        form.AddField("game", _nameCloneGame);

        using (UnityWebRequest www = UnityWebRequest.Post(_targetURL, form))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("successful!");
            }
            else
            {
                Debug.LogError("Error" + www.error);
            }

            _data = www.downloadHandler.text;//получение всей строки разбитой по принципу "название_колонки&значение_колонки" в данной строке

            DataReceived?.Invoke();
        }
    }
}


