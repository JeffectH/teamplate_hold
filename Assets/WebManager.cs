using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class WebManager : MonoBehaviour
{
    [SerializeField] private string _targetURL;
    [SerializeField] private string _nameCloneGame;

    private string _data;

    public string Data => _data;

    public void Initialize() 
    {
        StartCoroutine(SendData());
    }

    IEnumerator SendData()
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

            _data = www.downloadHandler.text;//получение все строки разбитой по принципу "название_колонки&знаечние_колонки" в данной строке
        }
    }


}


