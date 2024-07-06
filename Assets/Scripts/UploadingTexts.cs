using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UploadingTexts : MonoBehaviour, IUploadingData
{
    [SerializeField] private TextMeshProUGUI _textTitle;
    [SerializeField] private TextMeshProUGUI _textGesture;
    [SerializeField] private TextMeshProUGUI _textTask0;
    [SerializeField] private TextMeshProUGUI _textTask1;
    [SerializeField] private TextMeshProUGUI _textWin;

    public void Initialize(Dictionary<string, string> textData)
    {
        Uploading(textData);
    }

    public void Uploading(Dictionary<string, string> textData)
    {
        foreach (var kvp in textData)
        {
            string key = kvp.Key;
            string value = kvp.Value;

            switch (key)
            {
                case "textTitle":
                    _textTitle.text = value;
                    break;
                case "textGesture":
                    _textGesture.text = value;
                    break;
                case "textTask0":
                    _textTask0.text = value;
                    break;
                case "textTask1":
                    _textTask1.text = value;
                    break;
                case "textWin":
                    _textWin.text = value;
                    break;
                default:
                    Debug.LogWarning($"Unhandled key '{key}' in text data.");
                    break;
            }
        }
    }
}



