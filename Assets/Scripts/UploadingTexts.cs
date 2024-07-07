using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UploadingTexts : MonoBehaviour, IUploading
{
    [SerializeField] private TextMeshProUGUI _textTitle;
    [SerializeField] private TextMeshProUGUI _textGesture;
    [SerializeField] private string _textTask0;
    [SerializeField] private string _textTask1;
    [SerializeField] private string _textWin;

    public string TextTask0 => _textTask0;
    public string TextTask1 => _textTask1;
    public string TextWin => _textWin;

    public void Initialize(Dictionary<string, string> textData)
    {
        UploadingData(textData);
    }

    public void UploadingData(Dictionary<string, string> textData)
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
                    _textTask0 = value;
                    break;
                case "textTask1":
                    _textTask1 = value;
                    break;
                case "textWin":
                    _textWin = value;
                    break;
                default:
                    Debug.LogWarning($"Unhandled key '{key}' in text data.");
                    break;
            }
        }
    }
}



