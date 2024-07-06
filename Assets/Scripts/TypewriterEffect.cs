using System.Collections;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]

public class TypewriterEffect : MonoBehaviour
{
    [SerializeField] private float _delay = 0.1f; // Задержка между появлением букв

    private TextMeshProUGUI _textComponent;
    private string _currentText;

    private void Awake()
    {
        _textComponent = GetComponent<TextMeshProUGUI>();
    }

    public void StartEffect(string fullText)
    {
        StartCoroutine(ShowText(fullText));
    }

    private IEnumerator ShowText(string fullText)
    {
        for (int i = 0; i <= fullText.Length; i++)
        {
            _currentText = fullText.Substring(0, i);
            _textComponent.text = _currentText;
            yield return new WaitForSeconds(_delay);
        }
    }
}


