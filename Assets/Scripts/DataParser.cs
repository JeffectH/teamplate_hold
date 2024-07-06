using System.Collections.Generic;
using UnityEngine;

public class DataParser : MonoBehaviour
{
    private Dictionary<string, string> _imageData;
    private Dictionary<string, string> _textData;
    private Dictionary<string, string> _soundData;

    public Dictionary<string, string> ImageData => _imageData;
    public Dictionary<string, string> TextData => _textData;
    public Dictionary<string, string> SoundData => _soundData;

    public void Initialize(string dataString)
    {
        ExtractDataFromString(dataString);
    }

    private void ExtractDataFromString(string dataString)
    {
        var parsedData = ParseDataString(dataString);
        _imageData = parsedData.Item1;
        _textData = parsedData.Item2;
        _soundData = parsedData.Item3;
    }

    (Dictionary<string, string>, Dictionary<string, string>, Dictionary<string, string>) ParseDataString(string dataString)
    {
        Dictionary<string, string> imageData = new Dictionary<string, string>();
        Dictionary<string, string> textData = new Dictionary<string, string>();
        Dictionary<string, string> soundData = new Dictionary<string, string>();

        // Разбиваем строку по символу '&'
        string[] parts = dataString.Split('&');

        // Итерируем через части и извлекаем ключи и значения
        for (int i = 0; i < parts.Length; i += 2)
        {
            if (i + 1 < parts.Length) // Проверяем, что существует значение для ключа
            {
                string key = parts[i];
                string value = parts[i + 1];

                if (key.StartsWith("link"))
                {
                    imageData[key] = value;
                }
                else if (key.StartsWith("text"))
                {
                    textData[key] = value;
                }
                else if (key.StartsWith("sound"))
                {
                    soundData[key] = value;
                }
            }
        }

        return (imageData, textData, soundData);
    }
}
