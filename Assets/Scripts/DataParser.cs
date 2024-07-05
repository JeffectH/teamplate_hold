using System.Collections.Generic;
using UnityEngine;

public class DataParser : MonoBehaviour
{
    [SerializeField] private Dictionary<string, string> _dataString;

    public Dictionary<string, string> DataString => _dataString;


    public void Initialize(string dataString)
    {
        ExtractDataFromString(dataString);
    }

    private void ExtractDataFromString(string dataString)
    {
        _dataString = ParseDataString(dataString);
    }

    Dictionary<string, string> ParseDataString(string dataString)
    {
        Dictionary<string, string> data = new Dictionary<string, string>();

        // ��������� ������ �� ������� '&'
        string[] parts = dataString.Split('&');

        // ��������� ����� ����� � ��������� ����� � ��������
        for (int i = 0; i < parts.Length; i += 2)
        {
            if (i + 1 < parts.Length) // ���������, ��� ���������� �������� ��� �����
            {
                string key = parts[i];
                string value = parts[i + 1];
                data[key] = value;
            }
        }

        return data;
    }
}
